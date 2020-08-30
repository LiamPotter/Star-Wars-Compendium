using SWars.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace SWars.Tables
{
	public class SW_Table : MonoBehaviour
	{
		public SW_Table_Overlord Overlord;
		public SW_DataController.dataType TableType;
		public SW_Row TitleRow;
		public List<SW_Column> Columns;
		public List<SW_Row> Rows;
		public RectTransform TableContentHolder;
		private SW_Row tempRow0;
		private SW_Row tempRow1;
		private int currentSortID=0;
		private bool asc = false;
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
			LayoutElement[] elements = TableContentHolder.GetComponentsInChildren<LayoutElement>();
			foreach (LayoutElement element in elements)
			{
				Columns.Add(new SW_Column(element.minWidth, element.flexibleWidth == 1 ? true:false));
			}
		}
		public bool PopulateTable(List<BookItem> input)
		{
			for (int i = 0; i < input.Count; i++)
			{
				tempRow0 = CreateNewRow();
				tempRow0.AddNewItem(input[i].Name, Columns[0]);
				tempRow0.AddNewItem(input[i].System, Columns[1]);
				tempRow0.AddNewItem(input[i].Key, Columns[2]);
				Rows.Add(tempRow0);
			}
			return true;
		}

		private SW_Row CreateNewRow()
		{
			tempRow1 = Instantiate(Overlord.RowPrefab);
			tempRow1.transform.SetParent(TableContentHolder.transform,false);
			tempRow1.Overlord = Overlord;
			
			return tempRow1;
		}
		public void SortBy(int Item)
		{
			if (currentSortID == Item)
				asc = !asc;
			else asc = true;
			currentSortID = Item;
			Rows.Sort(delegate (SW_Row x, SW_Row y)
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
			for (int i = 0; i < Rows.Count; i++)
			{
				Rows[i].transform.SetSiblingIndex(2+i);
			}
		}

		public int SortAscending(string value1, string value2)
		{

			return value1.CompareTo(value2);
		}
	}
}