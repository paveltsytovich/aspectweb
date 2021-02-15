using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ptsytovich.Aspect.Web.Entities
{
    /// <summary>
    /// Exception for incorrect inherit controller with aspects features
    /// </summary>
    public class InheritControllerAspectException : AspectException
    {
        public InheritControllerAspectException() :
            base("Controller must be subclass of  AspectController")
        {

        }
    }
}
