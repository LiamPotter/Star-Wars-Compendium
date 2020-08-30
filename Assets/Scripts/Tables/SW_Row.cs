using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWars.Tables
{
	public class SW_Row : MonoBehaviour
	{
		public List<SW_Item> Items;
		public SW_Table_Overlord Overlord;
		public void AddNewItem(string inputText,SW_Column column)
		{
			SW_Item tempItem = Instantiate(Overlord.ItemPrefab);
			tempItem.transform.SetParent(transform);
			tempItem.Initialize(column.minWidth, column.flexWidth, inputText, Overlord);
			Items.Add(tempItem);
		}
		public void AddNewItem(string inputText,string navigation, SW_Column column)
		{
			SW_Item tempItem = Instantiate(Overlord.ItemNavPrefab);
			tempItem.transform.SetParent(transform);
			tempItem.Initialize(column.minWidth, column.flexWidth, inputText, Overlord, navigation);
			Items.Add(tempItem);
		}
	}
}