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
	}
}