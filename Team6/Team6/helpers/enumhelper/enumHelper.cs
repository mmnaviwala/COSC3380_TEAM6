using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Team6.helpers.enumhelper
{
    public static class enumHelper
    {
        public static SelectList GetSelectedItemList<T>() where T : struct
        {
            T t = default(T);

            if (!t.GetType().IsEnum)
            {
                throw new ArgumentNullException("Please try again");
            }
            var nameList = t.GetType().GetEnumNames();

            int counter = 0;
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            if (nameList != null && nameList.Length >0)
            {
                foreach (var name in nameList)
                {
                    T newEnum = (T)Enum.Parse(t.GetType(), name);
                    string description = getDescriptionFromEnumValue(newEnum as Enum);

                    if (!myDictionary.ContainsKey(counter))
                    {
                        myDictionary.Add(counter, description);

                    }
                    counter++;
                }
                counter=0;
            }
            return new SelectList(myDictionary, "Key", "Value");
        }

        private static string getDescriptionFromEnumValue(Enum value)
        {
            DescriptionAttribute descriptionAttribute =
                value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute),false)
                .SingleOrDefault() as DescriptionAttribute;

            return descriptionAttribute == null ? value.ToString() : descriptionAttribute.Description;
        }

        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}