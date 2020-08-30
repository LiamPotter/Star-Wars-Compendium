﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWars.Tables
{
	public class SW_Row : MonoBehaviour
	{
		public List<SW_Item> Items;
		public SW_Table Table;
		public SW_Table_Overlord Overlord;
		public string ItemID;
		
		public void AddNewItem(string inputText,SW_Column column)
		{
			SW_Item tempItem = Instantiate(Overlord.ItemPrefab);
			tempItem.transform.SetParent(transform,false);
			tempItem.Initialize(column.minWidth, column.flexWidth, inputText, Overlord,this);
			Items.Add(tempItem);
		}
		public void AddNewItem(string inputText,string navigation, SW_Column column)
		{
			SW_Item tempItem = Instantiate(Overlord.ItemNavPrefab);
			tempItem.transform.SetParent(transform,false);
			tempItem.Initialize(column.minWidth, column.flexWidth, inputText, Overlord,this, navigation);
			Items.Add(tempItem);
		}
		

	}
}