using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ptsytovich.Aspect.Web.Entities
{
    public class NoCallTimeAsceptException : AspectException
    {
        public NoCallTimeAsceptException()
            : base("No aspect for calltime. May be wrong Guard combination?")
        {

        }
    }
}
