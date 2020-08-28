using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SWars.Tables
{
	[System.Serializable]
	public class SW_Column 
	{
	
		public float minWidth;
		public bool flexWidth;
		public SW_Column(float min, bool flex)
		{
			minWidth = min;
			flexWidth = flex;
		}
	}
}
