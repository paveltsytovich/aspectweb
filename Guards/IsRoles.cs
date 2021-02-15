using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ptsytovich.Aspect.Web.Conditions;

namespace Ptsytovich.Aspect.Web.Guards
{
    public abstract class IsInRoles : IAspectPredicate
    {
        #region IAspectGuard Members
        public bool IsApplicable(Controllers.AspectController ownerController)
        {                
            String[] userRoles = GetApplicableRoles().Split(new char[] { '|',',' });
            foreach (var item in userRoles)
            {
                if (item.StartsWith("^") && ownerController.HttpContext.User.IsInRole(item.Substring(1)))
                    return false;                
                if (ownerController.HttpContext.User.IsInRole(item))
                    return true;
            }
            return false;        
        }
        #endregion
        public abstract String GetApplicableRoles();

    }
}
