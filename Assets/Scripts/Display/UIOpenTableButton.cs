using SWars.Data;
using SWars.Tables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SWars.UI
{
	public class UIOpenTableButton : MonoBehaviour
	{

		public SW_DataController.dataType TableType;
		private SW_Table_Overlord overlord;
		public void OpenTable()
		{
			if (!overlord)
				overlord = FindObjectOfType<SW_Table_Overlord>();
			overlord.OpenTable(TableType);
		}
	}
}