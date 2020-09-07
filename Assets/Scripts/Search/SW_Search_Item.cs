using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SWars.Data;
using UnityScript.Steps;

namespace SWars.Search
{
	public class SW_Search_Item : MonoBehaviour
	{
		public SW_Search_Display SearchDisplay;
		public SW_Search_Result Result;
		public TextMeshProUGUI Name, Type;
		private RectTransform rectTransform;

		public void ShowResult(SW_Search_Result result)
		{
			if (!rectTransform)
				rectTransform = GetComponent<RectTransform>();

			Result = result;
			Name.text = Result.Name;
			Type.text = Result.Type.ToString();

			float sizeMulti = 0;
			rectTransform.ForceUpdateRectTransforms();
			Name.rectTransform.ForceUpdateRectTransforms();
			Name.ForceMeshUpdate();
			int lines = Name.textInfo.lineCount;
			if (lines > 1)
				sizeMulti = lines;
			if (sizeMulti > 0)
			{
				float wantedSize = 0;
				wantedSize = 38 + (19 * sizeMulti - 1);
				rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, wantedSize);
			}

		}

		public void Open()
		{
			SearchDisplay.OpenItem(Result);
		}
	}
}
