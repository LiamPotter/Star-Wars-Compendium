using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using SWars.Data;
using SWars.Utils;
namespace SWars.Tables
{
	public class SW_Table_Overlord : MonoBehaviour
	{
		public SW_DataController dControl;
		public UIAnimation uIAnimation;
		public SW_Row RowPrefab;
		public SW_Item ItemNavPrefab;
		public SW_Item ItemPrefab;
		public List<SW_Table> Tables= new List<SW_Table>();
		public RectTransform AllTableScroller;

		private SW_Table tempTable;
		private SW_DataController.dataType tempDataType;
		private List<object> tempList;
		private bool firstPopulation = false;
		void Start()
		{
			if (!dControl)
				dControl = FindObjectOfType<SW_DataController>();
		}
		void Update()
		{
			if (dControl.Loaded)
				if (!firstPopulation)
					PopulateAllTables();
		}
		public void NavigateToItem(string navString)
		{

		}
		public void PopulateAllTables()
		{
			firstPopulation = true;
			tempDataType = SW_DataController.dataType.Book;
			tempTable =Tables.Find(x => x.TableType == tempDataType);
			tempTable.PopulateTable(dControl.Books.Items);
			//tempTable.gameObject.SetActive(false);
		}
		public void OpenTable(SW_DataController.dataType type)
		{
			tempTable = Tables.Find(x => x.TableType == tempDataType);
			tempTable.gameObject.SetActive(true);
			uIAnimation.ToggleHomePanel();
		}
	}
}
