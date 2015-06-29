using System;
using System.ComponentModel;

namespace DadosMongo.Comum
{
    public static class Comuns
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
