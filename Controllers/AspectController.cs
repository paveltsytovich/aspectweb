using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ptsytovich.Aspect.Web.Aspect;
using Ptsytovich.Aspect.Web.Conditions;
using Ptsytovich.Aspect.Web.Entities;

namespace Ptsytovich.Aspect.Web.Controllers
{
    /// <summary>
    /// Aspect controllers. This controllers must be base class for
    /// all controllers for this framework
    /// </summary>
    public class AspectController : Controller
    {
        internal IList<AspectData> _AspectsCallTime = new List<AspectData>();        
        private IDictionary<String, object> _AspectData = new Dictionary<String, object>();
        private IList<String> _ExecutedAspectsName = new List<String>();

        public IDictionary<String, object> AspectData
        {
            get { return _AspectData; }
        }
        
        internal bool _CancelAspects=false;
        public bool CancelAspects { get { return _CancelAspects; } }

        public String[] ExecuteCallTimeAspects()
        {
            if (_AspectsCallTime.Count == 0)
                throw new NoCallTimeAsceptException();
            foreach(var item in _AspectsCallTime.OrderByDescending(p => p.Order))
        	{
                if(item.Predicate.IsApplicable(this))
                    try
                    {
                        AspectData.Add(item.Action.GetType().FullName, item.Action.ExecuteAspect(this.AspectData));
                        _ExecutedAspectsName.Add(item.Action.GetType().FullName);
                    }
                    catch (Exception e)
                    {
                        _CancelAspects = true;
                        OnAspectException(item.Action, e);
                        throw e;
                    }
	        }           
            return _ExecutedAspectsName.ToArray();
        }
        public virtual ActionResult OnAspectException(IAspectAction Initiator, Exception e)
        {
            return null;
        }
        public virtual ActionResult GetActionResult(AspectResult result)
        {
            if (result.ResponseAction == AspectResult.AspectResponseAction.Route)
                return result.Data == null
                           ? RedirectToRoute(result.Name)
                           : RedirectToRoute(result.Name, result.Data);
            else 
                if(result.ResponseAction == AspectResult.AspectResponseAction.Action)
            {
                return result.Data == null
                           ? RedirectToAction(result.Name)
                           : RedirectToAction(result.Name, result.Data);
            }
            else
                {
                    return result.Name == null 
                        ? View(result.Data)  
                        : View(result.Name, result.Data);
                }        
        }
        
    }
}
