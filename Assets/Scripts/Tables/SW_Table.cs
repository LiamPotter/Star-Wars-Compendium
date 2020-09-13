using SWars.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using YamlDotNet.Samples;

namespace SWars.Tables
{
	public class SW_Table : MonoBehaviour
	{
		public SW_Table_Overlord Overlord;
		public GraphicRaycaster TableRaycaster;
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

        #region Table Functions
        public int RowShowAmount = 20;
		public GameObject ItemShowDropdown;
		public GameObject TableFunctionsHolder;
		public TMP_InputField SearchField;
		public SW_Table_Filter_Controller FilterControl;
		#endregion;

		[HideInInspector]
		public bool ShownFromBook=false;
		[HideInInspector]
		public List<SW_Row> RowsFromBook = new List<SW_Row>();
		public List<SW_Row> RowsFiltered = new List<SW_Row>();
		void Start()
		{
			if (!Overlord)
				Overlord = FindObjectOfType<SW_Table_Overlord>();
			if (!TableRaycaster)
				TableRaycaster = GetComponent<GraphicRaycaster>();
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
				Columns.Add(new SW_Column(TitleRow.Items[i].layout.minWidth, TitleRow.Items[i].layout.flexibleWidth == 1 ? true : false,TitleRow.Items[i].name));
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
				return P_PopulateTable(tBook.Items);
			}
			if(t==typeof(Gear))
			{
				Gear tGear = (Gear)input;
				return P_PopulateTable(tGear.Items);
			}
			if(t==typeof(Weapon))
			{
				Weapon tWeapon = (Weapon)input;
				return P_PopulateTable(tWeapon.Items);
			}
			return false;
		}
		private bool P_PopulateTable(List<BookItem> input)
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
		private bool P_PopulateTable(List<GearItem> input)
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
		private bool P_PopulateTable(List<WeaponItem> input)
		{
			TableItemType = input[0].GetType();
			for (int i = 0; i < input.Count; i++)
			{
				tempRow0 = CreateNewRow(input[i]);
				tempRow0.name = input[i].Name;
				tempRow0.AddNewDisplayItem(input[i].Name, Columns[0]);
				tempRow0.AddNewItem(input[i].Category, Columns[1]);
				tempRow0.AddNewItem(input[i].Skill, Columns[2]);
				tempRow0.AddNewItem(input[i].Damage.ToString(), Columns[3]);
				tempRow0.AddNewItem(input[i].Crit.ToString(), Columns[4]);
				tempRow0.AddNewItem(input[i].Range, Columns[5]);
				tempRow0.AddNewItem(input[i].Encumbrance.ToString(), Columns[6]);
				tempRow0.AddNewItem(input[i].HP.ToString(), Columns[7]);
				tempRow0.AddNewItem(input[i].Price.ToString(), Columns[8]);
				tempRow0.AddNewItem(input[i].Rarity.ToString(), Columns[9]);
				tempRow0.AddNewItem(input[i].Special, Columns[10]);
				string nav = Overlord.dControl.BookFromIndex(input[i].Index);
				tempRow0.AddNewItem(nav, Columns[11]);
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
			TableFunctionsHolder.SetActive(true);
			SearchField.gameObject.SetActive(false);
			SearchField.text = "";
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
			if (FilterControl.ActiveFilters.Count == 0)
				RefreshTable();
			else FilterTable(FilterControl.ActiveFilters);
		}
		public void ShowAllBookItems(string book)
		{
			CloseTable();
			ItemShowDropdown.SetActive(false);
			TableFunctionsHolder.SetActive(false);
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
		public void ToggleSearchField()
		{
			SearchField.gameObject.SetActive(!SearchField.gameObject.activeSelf);
			if (!SearchField.gameObject.activeSelf)
				RefreshTable();
			else
			{
				EventSystem.current.SetSelectedGameObject(SearchField.gameObject);
			}
		}
		public void ToggleSearchField(bool toggleTo)
		{
			SearchField.gameObject.SetActive(toggleTo);
		}
		public void ToggleFilters()
		{
			FilterControl.gameObject.SetActive(!FilterControl.gameObject.activeSelf);
			FilterControl.OpenFilters(TitleRow, Rows[0]);
		}
		public void ToggleFilters(bool toggleTo)
		{
			FilterControl.gameObject.SetActive(toggleTo);
			if(toggleTo)
				FilterControl.OpenFilters(TitleRow, Rows[0]);
		}
		public void SearchTable()
		{
			string searchInput = SearchField.text;
			bool match = false;
			List<SW_Row> rows;
			if (ShownFromBook)
				rows = RowsFromBook;
			else if (FilterControl.ActiveFilters.Count > 0)
				rows = RowsFiltered;
			else
				rows = Rows;
			for (int i = 0; i < rows.Count; i++)
			{
				match = false;
				for (int j = 0; j < rows[i].Items.Count; j++)
				{
					if (rows[i].Items[j].Value != null)
					{
						if (rows[i].Items[j].Value.ToLower().Contains(searchInput))
							match = true;
					}
				}
				rows[i].gameObject.SetActive(match);
			}
		}
		public void FilterTable(List<SW_Table_Filter> Filters)
		{
			if (Filters.Count == 0)
			{
				RefreshTable();
				return;
			}
			bool match = false;
			string searchString;
			string priceSort;
			int itemNum;
			int searchNum1, searchNum2;
			int rowAmount = 0;
			int col;
			
			for (int i = 0; i < Rows.Count; i++)
			{
				match = false;
				
				for (int l = 0; l < Filters.Count; l++)
				{
					col = Filters[l].columnID;
					switch (Filters[l].Type)
					{
						case SW_Table_Filter_Controller.FilterType.None:
							break;
						case SW_Table_Filter_Controller.FilterType.Dropdown:
							searchString = Filters[l].CurrentFilter.Text;
							if (searchString == "All")
								match = true;
							if (Rows[i].Items[col].Value != null)
							{
								if (Rows[i].Items[col].Value.Contains(searchString))
									match = true;
								else match = false;
							}
							else match = false;
							break;
						case SW_Table_Filter_Controller.FilterType.MinMax:
							if (Rows[i].Items[col].Value != null)
							{
								if (Int32.TryParse(Rows[i].Items[col].Value, out itemNum))
								{
									searchNum1 = Filters[l].CurrentFilter.Value1;
									searchNum2 = Filters[l].CurrentFilter.Value2;
									
									if (searchNum1 == -1)
									{
										if (itemNum <= searchNum2)
											match = true;
										else match = false;
									}
									else if (searchNum2 == -1)
									{
										if (itemNum >= searchNum1)
											match = true;
										else match = false;
									}
									else if (searchNum1 > searchNum2)
									{
										if (itemNum >= searchNum1)
										{
											match = true;
										}
										else match = false;
									}
									else if (itemNum == searchNum1 || itemNum == searchNum2)
										match = true;
									else if (itemNum >= searchNum1 && itemNum <= searchNum2)
										match = true;
									else match = false;
								}
							}
							break;
						case SW_Table_Filter_Controller.FilterType.Price:
							
							priceSort = Filters[l].CurrentFilter.SortType;
							if (Int32.TryParse(Rows[i].Items[col].Value, out itemNum))
							{
								searchNum1 = Filters[l].CurrentFilter.Value1;
								switch (priceSort)
								{
									case ">=":
										if (itemNum >= searchNum1)
											match = true;
										break;
									case ">":
										if (itemNum > searchNum1)
											match = true;
										break;
									case "<=":
										if (itemNum <= searchNum1)
											match = true;
										break;
									case "<":
										if (itemNum < searchNum1)
											match = true;
										break;
									case "=":
										if (itemNum == searchNum1)
											match = true;
										break;
									default:
										break;
								}
							}
							break;
						default:
							break;
					}
					if (!match)
						break;
				}
				if (match)
				{
					rowAmount++;
					if (!RowsFiltered.Contains(Rows[i]))
						RowsFiltered.Add(Rows[i]);
				}
				else
				{
					if (RowsFiltered.Contains(Rows[i]))
					{
						rowAmount--;
						RowsFiltered.Remove(Rows[i]);
					}
				}
				if (rowAmount >= RowShowAmount)
					Rows[i].gameObject.SetActive(false);
				else
					Rows[i].gameObject.SetActive(match);
			}
		}
		public List<string> RetrieveUniqueStrings(int columnID)
		{
			List<string> returnList = new List<string>();
			char[] divider = new char[] {','};
			for (int i = 0; i < Rows.Count; i++)
			{
				string itemValue = Rows[i].Items[columnID].Value;
				if (itemValue == null)
					continue;
				if(itemValue.Contains(','))
				{
					string[] itemValues = itemValue.Split(divider);
					for (int l = 0; l < itemValues.Length; l++)
					{
						if (!returnList.Contains(itemValues[l].Trim()))
						{
							returnList.Add(itemValues[l].Trim());
						}
					}
				}
				else if (!returnList.Contains(itemValue))
				{
					returnList.Add(itemValue);
				}
			}
			returnList.Sort(delegate (string x, string y)
			{
				if (x == null && y == null) return 0;
				else if (x == null) return -1;
				else if (y == null) return 1;
				else if (x == "" || x == "-") return -1;
				else if (y == "" || y == "-") return 1;
				else return String.Compare(x, y);
			});
			return returnList;
		}
		public void SortByInt(int Item)
		{
			List<SW_Row> rows;
			if (ShownFromBook)
				rows = RowsFromBook;
			else if (FilterControl.ActiveFilters.Count > 0)
				rows = RowsFiltered;
			else
				rows = Rows;
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
			if (!ShownFromBook && FilterControl.ActiveFilters.Count == 0)
				RefreshTable();
		}

		public void SortByString(int Item)
		{
			List<SW_Row> rows;
			if (ShownFromBook)
				rows = RowsFromBook;
			else if (FilterControl.ActiveFilters.Count > 0)
				rows = RowsFiltered;
			else
				rows = Rows;
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
			if (!ShownFromBook&&FilterControl.ActiveFilters.Count==0)
				RefreshTable();
		}

		
	}
}