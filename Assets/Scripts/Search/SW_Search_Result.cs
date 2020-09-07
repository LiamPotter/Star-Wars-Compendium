using SWars.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SW_Search_Result{

	public object SearchObject;
	public string Name;
	public string Subtitle;
	public SW_DataController.dataType Type;

	public SW_Search_Result(object searchObj,string name,string subtitle, SW_DataController.dataType type)
	{
		SearchObject = searchObj;
		Name = name;
		Type = type;
	}
}
