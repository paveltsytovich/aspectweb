using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ptsytovich.Aspect.Web.Entities
{
    public class NoPredicateAspectException : AspectException
    {
        public NoPredicateAspectException() : base("Aspect must have Predicate. Use 'Always' guard for unconditional trigged aspect")
        {

        }
    }
}
