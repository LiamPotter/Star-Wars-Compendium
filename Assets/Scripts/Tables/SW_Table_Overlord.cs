using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Reflection;
using UnityEngine;
using SWars.Data;
using SWars.Utils;
using System.Linq;
using System;

namespace SWars.Tables
{
	public class SW_Table_Overlord : MonoBehaviour
	{
		public SW_DataController dControl;
		public UIAnimation uIAnimation;
		public SW_Row RowPrefab;
		public SW_Item ItemNavPrefab;
		public SW_Item ItemDisplayPrefab;
		public SW_Item ItemPrefab;
		public SW_Item_Display ItemDisplay;
		public List<SW_Table> Tables= new List<SW_Table>();
		public RectTransform AllTableContent;

		private SW_Table tempTable;
		private SW_DataController.dataType tempDataType;
		private List<object> tempList;
		private bool firstPopulation = false;
		void Start()
		{
			if (!dControl)
				dControl = FindObjectOfType<SW_DataController>();
		}

		public void NavigateToItem(string navString)
		{

		}
		public void PopulateAllTables()
		{
			firstPopulation = true;
			for (int i = 0; i < Enum.GetValues(typeof(SW_DataController.dataType)).Length; i++)
			{
				tempTable = null;
				tempDataType = (SW_DataController.dataType)Enum.GetValues(typeof(SW_DataController.dataType)).GetValue(i);
				object tempObj = dControl.GetDataClass(tempDataType);
				tempTable = Tables.Find(x => x.TableType == tempDataType);
				if (tempTable == null)
				{
					Debug.Log("Couldn't find table for " + tempDataType);
				}
				else
				{
					Debug.Log("Populating " + tempObj.GetType().Name);
					tempTable.PopulateTable(tempObj);
					//tempTable.transform.SetParent(null);
					tempTable.gameObject.SetActive(false);
				}
			}
		}
		public void OpenTable(SW_DataController.dataType type)
		{
			if(tempTable)
			{
				tempTable.gameObject.SetActive(false);
				//tempTable.transform.SetParent(null);
			}
			tempTable = Tables.Find(x => x.TableType == type);
			//tempTable.transform.SetParent(AllTableContent);
			
			tempTable.gameObject.SetActive(true);
			//tempTable.ResizeAllRows();
			if (uIAnimation.HomePanelOpen)
				uIAnimation.ToggleHomePanel();
		}
		public void OpenItemDisplay(SW_DataController.dataType type,string name,string subtitle, object Item)
		{
			ItemDisplay.gameObject.SetActive(true);
			ItemDisplay.DisplayItem(type.ToString(), name, subtitle, StringString.MakeFromType(Item));
		}
	}
}
