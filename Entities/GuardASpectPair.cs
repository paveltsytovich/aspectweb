using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ptsytovich.Aspect.Web.Aspect;
using Ptsytovich.Aspect.Web.Conditions;

namespace Ptsytovich.Aspect.Web.Entities
{
    /// <summary>
    /// internal class for aspects infrastructure
    /// </summary>
    internal struct AspectData
    {
        public IAspectAction Action;
        public IAspectPredicate Predicate;
        public int Order;
    }
}
