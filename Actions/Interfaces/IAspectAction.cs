using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ptsytovich.Aspect.Web.Aspect
{
    /// <summary>
    /// Aspect action interface
    /// </summary>
    public interface IAspectAction
    {
        /// <summary>
        /// Method for implement aspect action
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Object ExecuteAspect(IDictionary<String, Object> aspectData);
    }
}
