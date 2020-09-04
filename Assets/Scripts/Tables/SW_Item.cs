using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace SWars.Tables
{
	public class SW_Item : MonoBehaviour
	{
		public LayoutElement layout;
		[HideInInspector]
		public TextMeshProUGUI textUI;
		private SW_Table_Overlord Overlord;
		public string NavString="";
		public string Value;
		public SW_Row itemRow;
		public GameObject[] ascdescImgs;
		[HideInInspector]
		public int itemID;
		public void Initialize(SW_Column column, string text, SW_Table_Overlord overlord, SW_Row row)
		{
			layout = GetComponent<LayoutElement>();
			textUI = GetComponentInChildren<TextMeshProUGUI>();
			if (!textUI)
				textUI = GetComponent<TextMeshProUGUI>();
			Overlord = overlord;
			itemRow = row;
			textUI.text = text;	
			Value = text;
			layout.minWidth = column.minWidth;
			if (column.flexWidth)
				layout.flexibleWidth = 1;
		}
		public void Initialize(float min, bool flex, string text, SW_Table_Overlord overlord, SW_Row row, string navigationString)
		{
			layout = GetComponent<LayoutElement>();
			textUI = GetComponentInChildren<TextMeshProUGUI>();
			if (!textUI)
				textUI = GetComponent<TextMeshProUGUI>();
			Overlord = overlord;
			itemRow = row;
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
			if (itemRow.Table.asc)
				ascdescImgs[0].SetActive(true);
			else ascdescImgs[1].SetActive(true);
		}
		public void PressedSortInt()
		{
			for (int i = 0; i < itemRow.Items.Count; i++)
			{
				itemRow.Items[i].DisableSortImages();
			}
			if (itemRow.Table.currentSortID == itemID)
				itemRow.Table.asc = !itemRow.Table.asc;
			else itemRow.Table.asc = true;
			EnableSortImage(itemRow.Table.asc);
			itemRow.Table.currentSortID = itemID;
			itemRow.Table.SortByInt(itemID);
		}
		public void PressedSortString()
		{
			for (int i = 0; i < itemRow.Items.Count; i++)
			{
				itemRow.Items[i].DisableSortImages();
			}
			if (itemRow.Table.currentSortID == itemID)
				itemRow.Table.asc = !itemRow.Table.asc;
			else itemRow.Table.asc = true;
			EnableSortImage(itemRow.Table.asc);
			itemRow.Table.currentSortID = itemID;
			itemRow.Table.SortByString(itemID);
		}
		public void PressedShowItem()
		{
			Overlord.OpenItemDisplay(itemRow.Table.TableType, itemRow.Items[0].Value, itemRow.Items[1].Value, itemRow.DatabaseObject);
		}
	}
}