using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SWars.Utils;
using SWars.Data;

namespace SWars.Tables
{
	public class SW_Item_Display : MonoBehaviour
	{
		public SW_DataController dataController;

		public SW_Table_Overlord overlord;

		public RectTransform rTransform;
		public ContentSizeFitter sizeFitter;

		public TextMeshProUGUI Type, Name, Subtitle;

		public List<UITitleAndValue> TitlesAndValues;

		private SW_DataController.dataType dataType;
		void Awake()
		{
			if (!dataController)
				dataController = FindObjectOfType<SW_DataController>();
			if (!overlord)
				overlord = FindObjectOfType<SW_Table_Overlord>();
			if (!rTransform)
				rTransform = GetComponent<RectTransform>();
			if (!sizeFitter)
				sizeFitter = GetComponent<ContentSizeFitter>();
		}
		
		public void DisplayItem(SW_DataController.dataType type,string name,string subtitle,List<StringString> values)
		{
			dataType = type;
			Type.text = type.ToString();
			SetName(name);
			Subtitle.text = subtitle;
			for (int i = 0; i < values.Count; i++)
			{
				if (values[i].String1 != "Index" && values[i].String1 != "GeneratedId")
				{
					if (values[i].String2 != name && values[i].String2 != subtitle)
					{
						TitlesAndValues[i].Set(values[i].String1, values[i].String2);
					}
				}
				else if(values[i].String1 == "Index")
				{
					if (!dataController)
						dataController = FindObjectOfType<SW_DataController>();
					TitlesAndValues[i].Set(values[i].String1, dataController.BookFromIndex(values[i].String2));
				}
			}
			rTransform.ForceUpdateRectTransforms();
			Canvas.ForceUpdateCanvases();
		}

		private void SetName(string name)
		{
			Name.text = name;
			float sizeMulti = 0;
			Name.rectTransform.ForceUpdateRectTransforms();
			Name.ForceMeshUpdate();
			int lines = Name.textInfo.lineCount;
			if (lines > 1)
				sizeMulti = lines;

			if (sizeMulti > 0)
			{
				float wantedSize = 0;
				wantedSize = 30 + (15 * sizeMulti - 1);
				Name.rectTransform.sizeDelta = new Vector2(Name.rectTransform.sizeDelta.x, wantedSize);
			}
		}
		public void BackToTable()
		{
			overlord.OpenTable(dataType);
			HideItem();
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