using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace DataLayerCommon.Helpers
{
    public static class EnumHelpers
    {
        // Get the value of the description attribute if the   
        // enum has one, otherwise use the value.  
        public static string GetDescription<TEnum>(this TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[]) fi?.GetCustomAttributes(typeof (DescriptionAttribute), false);

            return !(attributes?.Length > 0) ? value.ToString() : attributes[0].Description;
        }

        /// <summary>
        ///     Build a select list for an enum
        /// </summary>
        public static SelectList SelectListFor<T>() where T : struct
        {
            return new SelectList(BuildSelectListItems<T>(), "Value", "Text");
        }

        /// <summary>
        ///     Build a select list for an enum with a particular value selected
        /// </summary>
        public static SelectList SelectListFor<T>(T selected) where T : struct
        {
            return new SelectList(BuildSelectListItems<T>(), "Value", "Text", selected.ToString());
        }

        private static IEnumerable<SelectListItem> BuildSelectListItems<T>() where T : struct
        {
            return Enum.GetValues(typeof (T))
                .Cast<T>()
                .Select(e => new SelectListItem {Value = e.ToString(), Text = e.GetDescription()});
        }

        public static byte GetByteFromEnum<T>(string value)
        {
            return Convert.ToByte(Enum.Parse(typeof (T), value));
        }

        public static short GetShortFromEnum<T>(string value)
        {
            return Convert.ToInt16(Enum.Parse(typeof (T), value));
        }
    }
}