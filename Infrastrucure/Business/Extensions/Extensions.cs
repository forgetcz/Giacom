using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Business.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Get description from enum attributes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToDescriptionString<T>(this T val) where T : Enum
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString())!
               .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
