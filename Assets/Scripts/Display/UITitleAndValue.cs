using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class UITitleAndValue : MonoBehaviour {

	public TextMeshProUGUI Title, Value;
	public RectTransform rTransform;
	public void Set(string title, string value)
	{
		gameObject.SetActive(true);
		if (!rTransform)
			rTransform = GetComponent<RectTransform>();
		Title.text = title + ": ";
		Value.text = value;

		float sizeMulti = 0;
		Value.rectTransform.ForceUpdateRectTransforms();
		Value.ForceMeshUpdate();
		int lines = Value.textInfo.lineCount;
		if (lines > 1)
			sizeMulti = lines;
		
		if (sizeMulti > 0)
		{
			float wantedSize = 0;
			wantedSize = 20 + (10 * sizeMulti - 1);
			rTransform.sizeDelta = new Vector2(0, wantedSize);
		}
	}
}
