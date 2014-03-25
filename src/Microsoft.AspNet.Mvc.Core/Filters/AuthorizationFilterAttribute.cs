﻿using System;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        public abstract Task Invoke(AuthorizationFilterContext context, Func<Task> next);

        public int Order { get; set; }

        public bool IsPreambleFilter { get; set; }
    }
}
