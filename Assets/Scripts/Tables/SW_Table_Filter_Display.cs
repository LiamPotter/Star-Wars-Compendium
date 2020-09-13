using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SWars.Tables;

public class SW_Table_Filter_Display : MonoBehaviour {
	public TextMeshProUGUI Text;
	public ContentSizeFitter Fitter;
	public SW_Table_Filter Filter;
	public FilterAttributes filterAttrs;
	
	public void OpenFilter(string text)
	{
		Text.text = text;
		Text.ForceMeshUpdate();
		Text.rectTransform.ForceUpdateRectTransforms();
		//StartCoroutine(UpdateText());
	}
	private IEnumerator UpdateText()
	{
		Fitter.enabled = false;
		yield return new WaitForEndOfFrame();
		Fitter.enabled = true;
	}
	public void CloseFilter()
	{
		Filter.RemoveFilter();
		gameObject.SetActive(false);
	}
}
