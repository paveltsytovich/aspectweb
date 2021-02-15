using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ptsytovich.Aspect.Web.Controllers;
using Ptsytovich.Aspect.Web.Conditions;
using Ptsytovich.Aspect.Web.Aspect;
using Ptsytovich.Aspect.Web.Entities;

namespace Ptsytovich.Aspect.Web.Attributes
{
    /// <summary>
    /// Attribute for substitute controller action logic via user role
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class AspectAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Aspect conditional type
        /// </summary>
        public Type Predicate { get; set; }
        /// <summary>
        /// Aspect action type
        /// </summary>
        public Type Action { get; set; }
        /// <summary>
        /// When execution aspect
        /// </summary>              
        public ExecutionTime When { get; set; }

        private IAspectAction _action;
        private IAspectPredicate _guard;
        private ActionExecutingContext _filterContext;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _filterContext = filterContext;

            AspectController controller = (AspectController)filterContext.Controller;
            //put action parameters to AspectData collection
            foreach (var item in filterContext.ActionParameters)
            {
                controller.AspectData[item.Key] = item.Value;
            }
            //if (controller.Action != null) return;

            if (!filterContext.Controller.GetType().IsSubclassOf(typeof(AspectController)))
                throw new InheritControllerAspectException();

            if (Predicate == null)
                throw new NoPredicateAspectException();
            if (Action == null)
                throw new NoActionAsceptException();
            _guard = (IAspectPredicate)Predicate.Assembly.CreateInstance(Predicate.FullName);
                        
            _action= (IAspectAction)Action.Assembly.CreateInstance(Action.FullName);
            if (When == ExecutionTime.calltime)
                controller._AspectsCallTime.Add(new Entities.AspectData() { Action = _action, Predicate = _guard,Order = Order });
            else if (When == ExecutionTime.before)
            {
                if (_guard.IsApplicable(controller))
                    try
                    {
                        _action.ExecuteAspect(controller.AspectData);
                    }
                    catch (Exception e)
                    {
                        if(filterContext.Result == null)
                       filterContext.Result = controller.OnAspectException(_action, e);
                    }
            }            
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (When == ExecutionTime.after)
            {
                AspectController controller = (AspectController)filterContext.Controller;
                if (controller._CancelAspects == false && _guard.IsApplicable(controller))
                    try
                    {
                        _action.ExecuteAspect(controller.AspectData);
                    }
                    catch (Exception e)
                    {
                        filterContext.Result = controller.OnAspectException(_action, e);
                    }
            }
        }
    }
}
