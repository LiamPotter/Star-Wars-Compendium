using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SWars.Tables
{
	[System.Serializable]
	public class SW_Column 
	{
		public string title;
		public float minWidth;
		public bool flexWidth;
		public SW_Column(float min, bool flex,string columnTitle)
		{
			minWidth = min;
			flexWidth = flex;
			title = columnTitle;
		}
	}
}
