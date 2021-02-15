using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ptsytovich.Aspect.Web.Controllers;

namespace Ptsytovich.Aspect.Web.Conditions
{
    /// <summary>
    /// Aspect for trigged action aspect
    /// </summary>
    public interface IAspectPredicate
    {
        bool IsApplicable(AspectController ownerController);
    }
}
