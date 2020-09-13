using SWars.Tables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using YamlDotNet.Core.Tokens;

namespace SWars.Tables
{
	public class SW_Table_Filter : MonoBehaviour
	{
		public SW_Table_Filter_Controller.FilterType Type;
		private SW_Table_Filter_Controller Controller;

		public TextMeshProUGUI TitleText;
		public TMP_InputField Min, Max,Price;
		public TMP_Dropdown Dropdown;

		public FilterAttributes CurrentFilter;
		public SW_Table_Filter_Display Display;

		private string titleString;
		public int columnID;
		private List<string> dropdownOptions;

		public void Initialize(SW_Table_Filter_Controller control,SW_Table_Filter_Controller.FilterType type,string title, int column)
		{
			Controller = control;
			Type = type;
			titleString = title;
			TitleText.text = titleString;
			columnID = column;
			CurrentFilter = new FilterAttributes(titleString);
			Display = Instantiate(Controller.DisplayPrefab);
			Display.Filter = this;
			Display.filterAttrs = CurrentFilter;
			Display.transform.SetParent(Controller.FilterDisplayGrid.transform, false);
			Display.gameObject.SetActive(false);
		}
		public void SetDropdownOptions(List<string> options)
		{
			dropdownOptions = options;
			Dropdown.ClearOptions();
			options.Insert(0, "All");
			Dropdown.AddOptions(dropdownOptions);
		}
		public void UpdatePrice()
		{
			CurrentFilter.SetSortType(Dropdown.options[Dropdown.value].text);
			CurrentFilter.SetValue(Price.text);
			if (CurrentFilter.InUse)
				Controller.UpdateFilter(this);
			else RemoveFilter();
		}
		public void UpdateMinMax()
		{
			CurrentFilter.SetValue(Min.text,Max.text);
			if (CurrentFilter.InUse)
				Controller.UpdateFilter(this);
			else RemoveFilter();
		}
		public void UpdateText()
		{
			CurrentFilter.SetText(Dropdown.options[Dropdown.value].text);
			if (CurrentFilter.InUse)
				Controller.UpdateFilter(this);
			else RemoveFilter();
		}
		public void ShowFilterDisplay()
		{
			Display.OpenFilter(ParseFilter());
			Display.gameObject.SetActive(false);
			Display.gameObject.SetActive(true);
		}
		public void RemoveFilter()
		{
			switch (Type)
			{
				case SW_Table_Filter_Controller.FilterType.None:
					break;
				case SW_Table_Filter_Controller.FilterType.Dropdown:
					Dropdown.value = 0;
					break;
				case SW_Table_Filter_Controller.FilterType.MinMax:
					Min.text= "";
					Max.text= "";
					break;
				case SW_Table_Filter_Controller.FilterType.Price:
					Price.text = "";
					break;
				default:
					break;
			}
			Debug.Log("removing filter on " + gameObject.name);
			Controller.RemoveFilter(this);
		}
		public string ParseFilter()
		{
			string temp = "";
			switch (Type)
			{
				case SW_Table_Filter_Controller.FilterType.None:
					break;
				case SW_Table_Filter_Controller.FilterType.Dropdown:
					temp = titleString + ": "+CurrentFilter.Text;
					break;
				case SW_Table_Filter_Controller.FilterType.MinMax:
					if (CurrentFilter.Value1 != -1)
						temp += "Min " + titleString + ": " + CurrentFilter.Value1.ToString()+" ";
					if(CurrentFilter.Value2!=-1)
						temp += "Max " + titleString + ": " + CurrentFilter.Value2.ToString();
					break;
				case SW_Table_Filter_Controller.FilterType.Price:
					temp = "Price: " + CurrentFilter.SortType + " " + CurrentFilter.Value1;
					break;
				default:
					break;
			}
			return temp;
		}
	}
	public class FilterAttributes
	{
		private string title, textValue;
		private int numValue1, numValue2;
		public string Title { get { return title; } }
		public string Text { get { return textValue; } }
		public int Value1 { get { return numValue1; } }
		public int Value2 { get { return numValue2; } }

		private string sortType;
		public string SortType { get { return sortType; } }

		private bool inUse;
		public bool InUse { get { return inUse; } }
		public FilterAttributes(string titleName)
		{
			title = titleName;
		}
		public void SetText(string to)
		{
			textValue = to;
			if (textValue != ""&&textValue!="All")
			{
				inUse = true;
			}
			else inUse = false;
		}
		public void SetValue(int value1,int value2)
		{
			numValue1 = value1;
			numValue2 = value2;
			inUse = true;
		}
		public void SetValue(string value1, string value2)
		{
			if(value1==null&&value2==null)
			{
				inUse = false;
				return;
			}
			if (value1 == null)
				value1 = "-1";
			if (value2 == null)
				value2 = "-1";
			if (value1 == "" && value2=="")
			{
				inUse = false;
				return;
			}
			if (value1 == "")
				value1 = "-1";
			if (value2 == "")
				value2 = "-1";
			inUse = true;
			numValue1 = Int32.Parse(value1);
			numValue2 = Int32.Parse(value2);
		}
		public void SetValue(int value)
		{
			numValue1 = value;
		}
		public void SetValue(string value)
		{
			if(value=="")
			{
				inUse = false;
				return;
			}
			inUse = true;
			if (value != "")
				numValue1 = Int32.Parse(value);
			else numValue1 = -1;
		}
		public void SetSortType(string sort)
		{
			sortType = sort;
		}
		public void SetUse(bool to)
		{
			inUse = to;
		}
	}
}