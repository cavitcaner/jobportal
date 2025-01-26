using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Core.Helpers
{
    public class ExceptionHelper
    {
        public static void ThrowIf(bool condition, string message)
        {
            if (condition)
                throw new Exception(message);
        }
        public static void ThrowIfNullOrEmpty(object? obj, string message)
        {
            ThrowIf(obj == null, message);
            ThrowIf(obj is string str && string.IsNullOrEmpty(str), message);
        }
    }
}
