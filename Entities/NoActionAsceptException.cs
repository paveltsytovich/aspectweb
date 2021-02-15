using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ptsytovich.Aspect.Web.Entities
{
    /// <summary>
    /// Exception in no have action for aspect
    /// </summary>
    public class NoActionAsceptException : AspectException
    {
        public NoActionAsceptException()
            : base("Aspect must have action")
        {
            
        }
    }
}
