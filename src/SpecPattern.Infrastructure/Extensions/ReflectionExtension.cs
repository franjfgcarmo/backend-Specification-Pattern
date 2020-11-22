using System;
using System.Linq;

namespace SpecPattern.Infrastructure.Extensions
{
    public static class ReflectionExtension
    {
        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type baseType, string genericName)
        {
            while (toCheck != typeof(object))
            {
                Type cur = toCheck.IsGenericType && toCheck.GenericTypeArguments.Any(a => a.Name == genericName) ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (baseType == cur)
                {
                    return true;
                }

                toCheck = toCheck.BaseType;
            }

            return false;
        }
    }
}
