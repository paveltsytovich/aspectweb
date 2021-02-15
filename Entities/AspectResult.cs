using System;

namespace Ptsytovich.Aspect.Web.Entities
{
    public class AspectResult
    {
        public enum AspectResponseAction
        {
            Action,
            Route,
            View
        }

        public AspectResponseAction ResponseAction { get; set; }
        public String Name { get; set; }
        private bool Cancel { get; set; }
        public object Data { get; set; }
    }
}
