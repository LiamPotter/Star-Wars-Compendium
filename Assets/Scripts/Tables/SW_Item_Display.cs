using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SWars.Utils;

namespace SWars.Tables
{
	public class SW_Item_Display : MonoBehaviour
	{

		public TextMeshProUGUI Type, Name, Subtitle;

		public List<UITitleAndValue> TitlesAndValues;

		
		public void DisplayItem(string type,string name,string subtitle,List<StringString> values)
		{
			Type.text = type;
			Name.text = name;
			Subtitle.text = subtitle;
			for (int i = 0; i < values.Count; i++)
			{
				if (values[i].String1 != "Index" && values[i].String1 != "GeneratedId")
				{
					if (values[i].String2 != name && values[i].String2 != subtitle)
					{
						TitlesAndValues[i].gameObject.SetActive(true);
						TitlesAndValues[i].Title.text = values[i].String1+": ";
						TitlesAndValues[i].Value.text = values[i].String2;
					}
				}
			}
		}
		public void HideItem()
		{
			for (int i = 0; i < TitlesAndValues.Count; i++)
			{
				TitlesAndValues[i].gameObject.SetActive(false);
			}
			gameObject.SetActive(false);
		}
	}
}