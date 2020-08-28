using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace SWars.Tables
{
	public class SW_Item : MonoBehaviour
	{
		private LayoutElement layout;
		private TextMeshProUGUI textUI;
		public string NavString="";
		private SW_Table_Overlord Overlord;
		public void Initialize(float min,bool flex,string text,SW_Table_Overlord overlord)
		{
			layout = GetComponent<LayoutElement>();
			textUI = GetComponentInChildren<TextMeshProUGUI>();
			Overlord = overlord;
			textUI.text = text;
			layout.minWidth = min;
			if(flex)
				layout.flexibleWidth = 1;
		}
		public void Initialize(float min, bool flex, string text, SW_Table_Overlord overlord, string navigationString)
		{
			layout = GetComponent<LayoutElement>();
			textUI = GetComponentInChildren<TextMeshProUGUI>();
			Overlord = overlord;
			textUI.text = text;
			layout.minWidth = min;
			if (flex)
				layout.flexibleWidth = 1;
			NavString = navigationString;
		}
		public void NavigationEvent()
		{
			Overlord.NavigateToItem(NavString);
		}
	}
}