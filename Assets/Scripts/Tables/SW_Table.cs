using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SWars.Tables
{
	public class SW_Table : MonoBehaviour
	{
		public SW_Table_Overlord Overlord;
		public SW_Row TitleRow;
		public List<SW_Column> Columns;
		public List<SW_Row> Rows;
		public Transform TableContentHolder;
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
	}
}