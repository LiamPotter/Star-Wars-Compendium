using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
namespace SWars.Utils
{
    public class StringString
    {
        public string String1, String2;
        public StringString(string string1, string string2)
        {
            String1 = string1;
            String2 = string2;
        }
        public StringString(string string1)
        {
            String1 = string1;
            String2 = "";
        }
        public static List<StringString> MakeFromType(object input)
        {
            List<StringString> tempList = new List<StringString>();
            PropertyInfo[] props = input.GetType().GetProperties();
            string n ="", v = "";
            object propVal=null;
            for (int i = 0; i < props.Length; i++)
            {
                Debug.Log(props[i].Name + ": " + props[i].GetValue(input, null));
                n = props[i].Name;
                propVal = props[i].GetValue(input, null);
                if (propVal == null)
                    v = " ";
                else v = propVal.ToString();
                tempList.Add(new StringString(n, v));
            }
            return tempList;
        }
    }
}
