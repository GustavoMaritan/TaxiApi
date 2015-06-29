using System;
using System.ComponentModel;

namespace DadosMongo.Core
{
    public static class Core
    {
        public static string GetDescription(this Type type)
        {
            var descriptions = (DescriptionAttribute[])
                type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptions.Length == 0
                ? null
                : descriptions[0].Description; 
        }
    }
}
