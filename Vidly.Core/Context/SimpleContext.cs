using System;
using System.Collections.Generic;

namespace Vidly.Core.Context
{
    public sealed class SimpleContext : Dictionary<string, object>, IDisposable
    {
        [ThreadStatic]
        private static IDictionary<string, object> simpleContext = null;

        public SimpleContext() : base()
        {
            if (simpleContext == null)
                simpleContext = this;
        }

        public void Dispose()
        {
            if (simpleContext == this)
            {
                foreach (var item in simpleContext)
                {
                    if (item.Value is IDisposable)
                        ((IDisposable)item.Value).Dispose();
                }

                this.Clear();

                simpleContext = null;
            }
        }

        public static IDictionary<string, object> Current
        {
            get
            {
                return simpleContext;
            }
        }
    }
}
