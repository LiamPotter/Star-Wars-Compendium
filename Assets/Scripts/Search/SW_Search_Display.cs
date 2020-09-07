using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWars.Data;
using SWars.Tables;
using TMPro;

namespace SWars.Search
{
	public class SW_Search_Display : MonoBehaviour
	{
		public SW_Table_Overlord Overlord;
		public SW_Search_Item ItemPrefab;
		public RectTransform SearchTitle;
		public TextMeshProUGUI SearchText;
		public List<SW_Search_Item> DisplayList;
		public List<SW_Search_Result> Results;

		private List<SW_Search_Result> prevResults;
		public void ReopenSearch()
		{
			Results = prevResults;
			for (int i = 0; i < Results.Count; i++)
			{
				if (i >= DisplayList.Count)
					DisplayList.Add(NewItem());
				DisplayList[i].gameObject.SetActive(true);
				DisplayList[i].ShowResult(Results[i]);
			}
		}
		public void OpenSearch(string searchText,List<SW_Search_Result> results)
		{
			SearchText.text =  "\""+ searchText+"\"";

			float sizeMulti = 0;
			SearchText.rectTransform.ForceUpdateRectTransforms();
			SearchText.ForceMeshUpdate();
			int lines = SearchText.textInfo.lineCount;
			if (lines > 1)
				sizeMulti = lines;
			if (sizeMulti > 0)
			{
				float wantedSize = 0;
				wantedSize = 38 + (19 * sizeMulti - 1);
				SearchTitle.sizeDelta = new Vector2(SearchTitle.sizeDelta.x, wantedSize);
			}

			Results = results;
			for (int i = 0; i < Results.Count; i++)
			{
				if (i >= DisplayList.Count)
					DisplayList.Add(NewItem());
				DisplayList[i].gameObject.SetActive(true);
				DisplayList[i].ShowResult(Results[i]);
			}
		}

		public void OpenItem(SW_Search_Result result)
		{
			if (!Overlord)
				Overlord = FindObjectOfType<SW_Table_Overlord>();
			Overlord.OpenItemDisplay(result.Type, result.Name, result.Subtitle, result.SearchObject);
			CloseSearch();
		}
		public void CloseSearch()
		{
			for (int i = 0; i < DisplayList.Count; i++)
			{
				DisplayList[i].gameObject.SetActive(false);
			}
			prevResults = Results;
			Results.Clear();
		}
		private SW_Search_Item NewItem()
		{
			SW_Search_Item temp = Instantiate(ItemPrefab);
			temp.transform.SetParent(transform, false);
			return temp;
		}
	}
}