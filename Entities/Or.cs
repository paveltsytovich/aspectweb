using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ptsytovich.Aspect.Web.Conditions;

namespace Ptsytovich.Aspect.Web.Entities
{
    /// <summary>
    ///  Predicate OR for aspect`s condition
    /// </summary>
    /// <typeparam name="K1"></typeparam>
    /// <typeparam name="K2"></typeparam>
    public class Or<K1,K2> : IAspectPredicate
        where K1 : IAspectPredicate,new()
        where K2 : IAspectPredicate,new()
    {
        private K1 _guard1 = new K1();
        private K2 _guard2 = new K2();
        #region IAspectGuard Members

        public bool IsApplicable(Controllers.AspectController ownerController)
        {
            return _guard1.IsApplicable(ownerController) ||
                _guard2.IsApplicable(ownerController);
        }

        #endregion
    }
}
