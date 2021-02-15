using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ptsytovich.Aspect.Web.Conditions;

namespace Ptsytovich.Aspect.Web.Entities
{
    /// <summary>
    ///  Predicate NOT for aspect`s condition
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public class Not<K> : IAspectPredicate
        where K : IAspectPredicate,new() 
    {
        private K _guard = new K();
        #region IAspectGuard Members

        public bool IsApplicable(Controllers.AspectController ownerController)
        {
            return !_guard.IsApplicable(ownerController);
        }

        #endregion
    }
}
