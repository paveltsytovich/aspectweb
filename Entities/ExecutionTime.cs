using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ptsytovich.Aspect.Web.Entities
{
    /// <summary>
    /// Time of aspect execution
    /// </summary>
    public enum ExecutionTime
    {
        /// <summary>
        /// On time call Action by ExecuteCallTimeAspect() method of AspectController
        /// </summary>
        calltime = 0,
        /// <summary>
        /// Aspect execute before call action
        /// </summary>
        before = 1,        
        /// <summary>
        /// Aspect execute after call action
        /// </summary>
        after = 2
    }
}
