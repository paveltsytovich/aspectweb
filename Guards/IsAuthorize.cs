using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ptsytovich.Aspect.Web.Conditions;

namespace Ptsytovich.Aspect.Web.Guards
{
    public class IsAuthorized : IAspectPredicate
    {
        #region IAspectGuard Members

        public bool IsApplicable(Controllers.AspectController ownerController)
        {
            return ownerController.HttpContext.User.Identity.IsAuthenticated;
        }

        #endregion
    }
}
