using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

namespace SWars.Utils
{
	public static class ReflectionHelper
	{

		public static object GetField(object obj, string propertyName)
		{
			
			return obj.GetType().GetField(propertyName).GetValue(obj);
		}
		public static object GetProperty(object obj, string propertyName)
		{
			
			return obj.GetType().GetProperty(propertyName).GetValue(obj,null);
		}
		public static T GetProperty<T>(object obj, string propertyName)
		{
			return (T)obj.GetType().GetProperty(propertyName).GetValue(obj, null);
		}
	}
}