using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SWars.Tables
{
	public class SW_Row : MonoBehaviour
	{
		public object DatabaseObject;
		public List<SW_Item> Items = new List<SW_Item>();
		public RectTransform rTransform;
		public SW_Table Table;
		public SW_Table_Overlord Overlord;
		public string ItemID;
		public HorizontalLayoutGroup hLayout;
		public void AddNewDisplayItem(string inputText,SW_Column column)
		{
			SW_Item tempItem = Instantiate(Overlord.ItemDisplayPrefab);
			tempItem.transform.SetParent(transform, false);
			tempItem.Initialize(column, inputText, Overlord, this);
			Items.Add(tempItem);
		}
		public void AddNewItem(string inputText,SW_Column column)
		{
			SW_Item tempItem = Instantiate(Overlord.ItemPrefab);
			tempItem.transform.SetParent(transform,false);
			tempItem.Initialize(column, inputText, Overlord,this);
			Items.Add(tempItem);
		}
		public void AddNewItem(string inputText,string navigation, SW_Column column)
		{
			SW_Item tempItem = Instantiate(Overlord.ItemNavPrefab);
			tempItem.transform.SetParent(transform,false);
			tempItem.Initialize(column.minWidth, column.flexWidth, inputText, Overlord,this, navigation);
			Items.Add(tempItem);
		}
		public void SetNavString(string nav)
		{
			Items[Items.Count-1].NavString = nav;
		}
		public void ScaleHeightToFit()
		{
			float tempMulti = 0;
			float sizeMulti = 1;

			for (int i = 0; i < Items.Count; i++)
			{
				Items[i].textUI.rectTransform.ForceUpdateRectTransforms();
				Items[i].textUI.ForceMeshUpdate();
				tempMulti = Items[i].textUI.textInfo.lineCount;
				if (tempMulti>sizeMulti)
				{
					sizeMulti = tempMulti;
				}
			}
			float wantedSize = 0;
			if (sizeMulti>1)
			{
				if(sizeMulti>=4)
					wantedSize= 22 + (16 * sizeMulti - 1);
				else
					wantedSize= 22 + (11* sizeMulti - 1);
				rTransform.sizeDelta = new Vector2(0, wantedSize);
			}
			//Debug.Log("Biggest string in " + name + "= " + biggestString);
		}
		public void DisableScaling()
		{
			if (!hLayout)
				hLayout = GetComponent<HorizontalLayoutGroup>();
			hLayout.enabled = false;
		}

	}
}