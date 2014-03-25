﻿using System.Collections.Generic;

namespace Microsoft.AspNet.Mvc
{
    public class FilterDescriptorOrderComparer : IComparer<FilterDescriptor>
    {
        private static readonly FilterDescriptorOrderComparer _comparer = new FilterDescriptorOrderComparer();

        public static FilterDescriptorOrderComparer Comparer { get { return _comparer; } }

        public int Compare([NotNull]FilterDescriptor x, [NotNull]FilterDescriptor y)
        {
            if (x.IsPreambleFilter && y.IsPreambleFilter)
            {
                if (x.Order == y.Order)
                {
                    return y.Scope.CompareTo(x.Scope);
                }
                else
                {
                    return x.Order.CompareTo(y.Order);
                }
            }
            else if (x.IsPreambleFilter)
            {
                return -1;
            }
            else if (y.IsPreambleFilter)
            {
                return 1;
            }
            else
            {
                if (x.Order == y.Order)
                {
                    return x.Scope.CompareTo(y.Scope);
                }
                else
                {
                    return x.Order.CompareTo(y.Order);
                }
            }
        }
    }
}
