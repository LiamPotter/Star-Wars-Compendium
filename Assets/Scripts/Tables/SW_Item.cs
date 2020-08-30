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
		private SW_Table_Overlord Overlord;
		public string NavString="";
		public string Value;
		public SW_Row row;
		public GameObject[] ascdescImgs;
		public void Initialize(float min, bool flex, string text, SW_Table_Overlord overlord, SW_Row row)
		{
			layout = GetComponent<LayoutElement>();
			textUI = GetComponentInChildren<TextMeshProUGUI>();
			Overlord = overlord;
			textUI.text = text;
			Value = text;
			layout.minWidth = min;
			if(flex)
				layout.flexibleWidth = 1;
		}
		public void Initialize(float min, bool flex, string text, SW_Table_Overlord overlord, SW_Row row, string navigationString)
		{
			layout = GetComponent<LayoutElement>();
			textUI = GetComponentInChildren<TextMeshProUGUI>();
			Overlord = overlord;
			textUI.text = text;
			Value = text;
			layout.minWidth = min;
			if (flex)
				layout.flexibleWidth = 1;
			NavString = navigationString;
		}
		public void NavigationEvent()
		{
			Overlord.NavigateToItem(NavString);
		}
		public void DisableSortImages()
		{
			ascdescImgs[0].SetActive(false);
			ascdescImgs[1].SetActive(false);
		}
		public void EnableSortImage(bool asc)
		{
			Debug.Log(asc);
			if (asc)
				ascdescImgs[0].SetActive(true);
			else ascdescImgs[1].SetActive(true);
		}
		public void PressedSort(int itemID)
		{
			for (int i = 0; i < row.Items.Count; i++)
			{
				row.Items[i].DisableSortImages();
			}
			if (row.Table.currentSortID == itemID)
				row.Table.asc = !row.Table.asc;
			else row.Table.asc = true;
			EnableSortImage(row.Table.asc);
			row.Table.currentSortID = itemID;
			row.Table.SortBy(itemID);
		}
	}
}