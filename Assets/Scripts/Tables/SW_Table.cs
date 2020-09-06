using SWars.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

namespace SWars.Tables
{
	public class SW_Table : MonoBehaviour
	{
		public SW_Table_Overlord Overlord;
		public SW_DataController.dataType TableType;
		public Type TableItemType;
		public SW_Row TitleRow;
		public List<SW_Column> Columns;
		public List<SW_Row> Rows;
		
		public RectTransform TableContentHolder;
		private SW_Row tempRow0;
		private SW_Row tempRow1;
		[HideInInspector]
		public int currentSortID=0;
		[HideInInspector]
		public bool asc = false;

		public int RowShowAmount = 20;
		public GameObject ItemShowDropdown;

		public bool ShownFromBook=false;
		[HideInInspector]
		public List<SW_Row> RowsFromBook = new List<SW_Row>();
		void Start()
		{
			if (!Overlord)
				Overlord = FindObjectOfType<SW_Table_Overlord>();
			if (Columns.Count == 0)
			{
				GetColumnsFromTitleRow();
			}
		}
		
		public void GetColumnsFromTitleRow()
		{
			Columns = new List<SW_Column>();
			for (int i = 0; i < TitleRow.Items.Count; i++)
			{
				TitleRow.Items[i].itemID = i;
				Columns.Add(new SW_Column(TitleRow.Items[i].layout.minWidth, TitleRow.Items[i].layout.flexibleWidth == 1 ? true : false));
			}
		}
		public bool PopulateTable(object input)
		{
			if (Columns.Count == 0)
				GetColumnsFromTitleRow();
			Type t = input.GetType();
			if (t== typeof(Book))
			{
				Book tBook = (Book)input;
				return PrivatePopulateTable(tBook.Items);
			}
			if(t==typeof(Gear))
			{
				Gear tGear = (Gear)input;
				return PrivatePopulateTable(tGear.Items);
			}
			return false;
		}
		private bool PrivatePopulateTable(List<BookItem> input)
		{
			TableItemType = input[0].GetType();
			for (int i = 0; i < input.Count; i++)
			{
				tempRow0 = CreateNewRow(input[i]);
				tempRow0.name = input[i].Name;
				tempRow0.AddNewDisplayItem(input[i].Name, Columns[0]);
				tempRow0.AddNewItem(input[i].System, Columns[1]);
				tempRow0.AddNewItem(input[i].Key, Columns[2]);
				Rows.Add(tempRow0);
			}
			return true;
		}
		private bool PrivatePopulateTable(List<GearItem> input)
		{
			TableItemType = input[0].GetType();
			for (int i = 0; i < input.Count; i++)
			{
				tempRow0 = CreateNewRow(input[i]);
				tempRow0.name = input[i].Name;
				tempRow0.AddNewDisplayItem(input[i].Name, Columns[0]);
				tempRow0.AddNewItem(input[i].Category, Columns[1]);
				tempRow0.AddNewItem(input[i].Price.ToString(), Columns[2]);
				tempRow0.AddNewItem(input[i].Rarity.ToString(), Columns[3]);
				tempRow0.AddNewItem(input[i].Encumbrance.ToString(), Columns[4]);
				tempRow0.AddNewItem(input[i].Notes, Columns[5]);
				string nav = Overlord.dControl.BookFromIndex(input[i].Index);
				tempRow0.AddNewItem(nav, Columns[6]);
				tempRow0.SetNavString(nav);
				Rows.Add(tempRow0);
			}
			ResizeAllRows();
			return true;
		}

		private SW_Row CreateNewRow(object databaseObject)
		{
			tempRow1 = Instantiate(Overlord.RowPrefab);
			tempRow1.transform.SetParent(TableContentHolder.transform,false);
			tempRow1.Overlord = Overlord;
			tempRow1.Table = this;
			tempRow1.DatabaseObject = databaseObject;
			return tempRow1;
		}
		public void ResizeAllRows()
		{
			Canvas.ForceUpdateCanvases();
			for (int i = 0; i < Rows.Count; i++)
			{
				Rows[i].ScaleHeightToFit();
			}
		}
		public void OpenTable()
		{
			ItemShowDropdown.SetActive(true);
			ShownFromBook = false;
			for (int i = 0; i < Rows.Count; i++)
			{
				if (i <= RowShowAmount)
				{
					Rows[i].gameObject.SetActive(true);
				}
			}
			ResizeAllRows();
		}
		public void CloseTable()
		{
			for (int i = 0; i < Rows.Count; i++)
			{
				if (Rows[i].gameObject.activeSelf)
					Rows[i].gameObject.SetActive(false);
			}
		}
		public void RefreshTable()
		{
			CloseTable();
			OpenTable();
		}
		public void UpdateShownRows(int newValue)
		{
			int rows = 25;
			switch (newValue)
			{
				case 0:
					rows = 25;
					break;
				case 1:
					rows = 50;
					break;
				case 2:
					rows = 100;
					break;
				case 3:
					rows = Rows.Count;
					break;
				default:
					break;
			}
			RowShowAmount = rows;
			
			RefreshTable();
		}
		public void ShowAllBookItems(string book)
		{
			CloseTable();
			ItemShowDropdown.SetActive(false);
			RowsFromBook.Clear();
			ShownFromBook = true;
			for (int i = 0; i < Rows.Count; i++)
			{
				if (Rows[i].Items[Rows[i].Items.Count - 1].NavString.Contains(book))
				{
					Rows[i].gameObject.SetActive(true);
					RowsFromBook.Add(Rows[i]);
				}
			}
		}
		public void SortByInt(int Item)
		{
			List<SW_Row> rows;
			if (ShownFromBook)
				rows = RowsFromBook;
			else rows = Rows;
			rows.Sort(delegate (SW_Row x, SW_Row y)
			{
				if (asc)
				{
					if (x.Items[Item] == null && y.Items[Item] == null) return 0;
					else if (x.Items[Item] == null) return -1;
					else if (y.Items[Item] == null) return 1;
					else if (x.Items[Item].Value == ""||x.Items[Item].Value=="-") return -1;
					else if (y.Items[Item].Value == "" || y.Items[Item].Value == "-") return 1;
					else return Int32.Parse(x.Items[Item].Value).CompareTo(Int32.Parse(y.Items[Item].Value));
				}
				else
				{
					if (x.Items[Item] == null && y.Items[Item] == null) return 0;
					else if (x.Items[Item] == null) return 1;
					else if (y.Items[Item] == null) return -1;
					else if (x.Items[Item].Value == "" || x.Items[Item].Value == "-") return 1;
					else if (y.Items[Item].Value == "" || y.Items[Item].Value == "-") return -1;
					else return Int32.Parse(y.Items[Item].Value).CompareTo(Int32.Parse(x.Items[Item].Value));
				}
			});
			for (int i = 0; i < rows.Count; i++)
			{
				rows[i].transform.SetSiblingIndex(2 + i);
			}
			if (!ShownFromBook)
				RefreshTable();
		}

		public void SortByString(int Item)
		{
			List<SW_Row> rows;
			if (ShownFromBook)
				rows = RowsFromBook;
			else rows = Rows;
			rows.Sort(delegate (SW_Row x, SW_Row y)
			{
				if (asc)
				{
					if (x.Items[Item] == null && y.Items[Item] == null) return 0;
					else if (x.Items[Item] == null) return -1;
					else if (y.Items[Item] == null) return 1;
					else return String.Compare(x.Items[Item].Value, y.Items[Item].Value);
				}
				else
				{
					if (x.Items[Item] == null && y.Items[Item] == null) return 0;
					else if (x.Items[Item] == null) return 1;
					else if (y.Items[Item] == null) return -1;
					else return String.Compare(y.Items[Item].Value, x.Items[Item].Value);
				}
			});
			for (int i = 0; i < rows.Count; i++)
			{
				rows[i].transform.SetSiblingIndex(2 + i);
			}
			if (!ShownFromBook)
				RefreshTable();
		}

		
	}
}