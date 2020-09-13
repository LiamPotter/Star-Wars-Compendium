using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;

namespace SWars.Tables
{
	public class SW_Table_Filter_Controller : MonoBehaviour
	{
		public SW_Table Table;
		public ContentSizeFitter fitter;
		private SW_Row TitleRow;
		public SW_Table_Filter DropdownPrefab, MinMaxPrefab, PricePrefab;
		public List<SW_Table_Filter> Filters;
		public List<SW_Table_Filter> ActiveFilters;
		public SW_Table_Filter_Display DisplayPrefab;
		public UIFlexibleGrid FilterDisplayGrid;

		private GraphicRaycaster filterRaycaster;
		private PointerEventData clickData;
		private List<RaycastResult> clickResults;
		public enum FilterType
		{
			None,Dropdown,MinMax,Price
		}
		void Start()
		{
			if (!Table)
				Table = GetComponentInParent<SW_Table>();
			if (!fitter)
				fitter = GetComponent<ContentSizeFitter>();
			filterRaycaster = GetComponent<GraphicRaycaster>();
			Filters = new List<SW_Table_Filter>();
			Filters.Clear();
			ActiveFilters = new List<SW_Table_Filter>();
		}
		void Update()
		{
			if(Input.GetMouseButtonDown(0))
			{
				clickData = new PointerEventData(Table.Overlord.MainEventSystem);
				clickData.position = Input.mousePosition;
				clickResults = new List<RaycastResult>();
				filterRaycaster.Raycast(clickData, clickResults);
				if (clickResults.Count == 0)
					Table.ToggleFilters(false);
			}
		}

		/// <summary>
		/// Open the filters menu for the selected table
		/// </summary>
		/// <param name="titleRow">The table's title row. Used to set Filter titles</param>
		/// <param name="valueRow">The table's first actual row, used to find what filters need to be created for this table.</param>
		public void OpenFilters(SW_Row titleRow,SW_Row valueRow)
		{
			TitleRow = titleRow;
			if(Filters.Count==0)
			{
				Filters = new List<SW_Table_Filter>();
				if (GetComponentsInChildren<SW_Table_Filter>().Length>0)
				{
					for (int i = 0; i < GetComponentsInChildren<SW_Table_Filter>().Length; i++)
					{
						Filters.Add(GetComponentsInChildren<SW_Table_Filter>()[i]);
					}
					return;
				}
				string title = "";
				List<string> propNames=  new List<string>();
				PropertyInfo propInfo;
				FilterType fType=0;
				SW_Table_Filter filter = null;
				for (int i = 0; i < valueRow.DatabaseObject.GetType().GetProperties().Length; i++)
				{
					propNames.Add(valueRow.DatabaseObject.GetType().GetProperties()[i].Name) ;
				}
				for (int i = 0; i < propNames.Count; i++)
				{
					filter = null;
					fType = FilterType.None;
					string lower = propNames[i].ToLower();
					int ID = 0;
					for (int j = 0; j < TitleRow.Items.Count-1; j++)
					{
						if (!lower.Contains("price") && !lower.Contains("notes")&& !lower.Contains("name"))
						{
							if (TitleRow.Items[j].name.ToLower().Contains(lower))
							{
								propInfo = valueRow.DatabaseObject.GetType().GetProperty(propNames[i]);
								if (propInfo.PropertyType == typeof(string))
								{
									int num = 0;
									if (Int32.TryParse(valueRow.Items[j].Value, out num))
										fType = FilterType.MinMax;
									else
										fType = FilterType.Dropdown;
								}
								else fType = FilterType.MinMax;
								ID = j;
								title = propInfo.Name;
							}
							
						}
						else if (lower.Contains("price")&& TitleRow.Items[j].name.ToLower().Contains("price"))
						{
							title = "Price";
							fType = FilterType.Price;
							ID = j;
						}
						//Debug.Log(lower +"-"+ fType);
					}
					switch (fType)
					{
						case FilterType.Dropdown:
							filter = Instantiate(DropdownPrefab);
							filter.SetDropdownOptions(Table.RetrieveUniqueStrings(ID));
							break;
						case FilterType.MinMax:
							filter = Instantiate(MinMaxPrefab);
							break;
						case FilterType.Price:
							filter = Instantiate(PricePrefab);
							break;
						case FilterType.None:
							filter = null;
							break;
						default:
							filter = null;
							break;
					}
					if (filter)
					{
						Filters.Add(filter);
						filter.transform.SetParent(transform, false);
						filter.Initialize(this, fType, title, ID);
					}
				}
				fitter.enabled = false;
				fitter.enabled = true;
			}
			if(fitter.enabled)
				StartCoroutine(DisableFitting());


		}
		public void UpdateFilter(SW_Table_Filter newFilter)
		{
			newFilter.ShowFilterDisplay();
			FilterDisplayGrid.UpdateGrid();
			if (!ActiveFilters.Contains(newFilter))
				ActiveFilters.Add(newFilter);
			Table.FilterTable(ActiveFilters);
		}
		public void RemoveFilter(SW_Table_Filter removeFilter)
		{
			ActiveFilters.Remove(removeFilter);
			removeFilter.Display.gameObject.SetActive(false);
			Table.FilterTable(ActiveFilters);
			FilterDisplayGrid.UpdateGrid();
		}
		public void RemoveAllFilters()
		{
			for (int i = 0; i < ActiveFilters.Count; i++)
			{
				ActiveFilters[i].RemoveFilter();
			}
		}
		public IEnumerator DisableFitting()
		{
			yield return new WaitForSeconds(0.1f);
			fitter.enabled = false;
			GetComponent<GridLayoutGroup>().enabled = false;
		}
		
	}
}