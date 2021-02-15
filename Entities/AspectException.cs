using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ptsytovich.Aspect.Web.Entities
{
    /// <summary>
    /// Aspect Exceptions base class
    /// </summary>
   public class AspectException : Exception
    {
       public AspectException(String Message) : base(Message)
       {

       }
    }
}
