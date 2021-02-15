using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ptsytovich.Aspect.Web.Conditions;

namespace Ptsytovich.Aspect.Web.Guards
{
    /// <summary>
    /// Default trigger for aspect. Always enabled to handle aspect
    /// </summary>
    public class Always : IAspectPredicate
    {
        #region IAspectGuard Members

        public bool IsApplicable(Controllers.AspectController ownerController)
        {
            return true;
        }

        #endregion
    }
}
