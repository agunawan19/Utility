using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities
{
    public static class Extensions
    {
        public static bool IsBetween<T>(this T value, T lowerBound, T upperBound, bool isEqualIncluded = true)
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            if (isEqualIncluded)
            {
                return value.CompareTo(lowerBound) >= 0 && value.CompareTo(upperBound) <= 0;
            }
            else
            {
                return value.CompareTo(lowerBound) > 0 && value.CompareTo(upperBound) < 0;
            }
            
        }
    }
}
