using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIFlexibleGrid : MonoBehaviour {

	public float XPadding, YPadding;
	public float ItemHeight;
	private RectTransform rectTransform;
	private float xWidth { get { return rectTransform.sizeDelta.x; } }
	void Start()
	{
		if(!rectTransform)
			rectTransform = GetComponent<RectTransform>();
		UpdateGrid();
	}
	void OnEnable()
	{
		if (!rectTransform)
			rectTransform = GetComponent<RectTransform>();
		UpdateGrid();
	}
	public void UpdateGrid()
	{
		if (transform.childCount == 0)
			return;
		float remainingWidth = xWidth;
		float rows = 0;
		for (int i = 0; i < rectTransform.childCount; i++)
		{
			RectTransform child = rectTransform.GetChild(i).GetComponent<RectTransform>();
			Vector2 newPosition = new Vector2();
			if (!child)
				continue;
			if (!child.gameObject.activeSelf)
				continue;
			if (remainingWidth < 0)
				rows += 1;
			newPosition.y = (child.sizeDelta.y - (Mathf.Abs(child.sizeDelta.y) * rows)) + YPadding;
			newPosition.x = (xWidth - remainingWidth);
			child.localPosition = newPosition;
				
			remainingWidth -= child.sizeDelta.x;
			remainingWidth -= XPadding;
		}
	}

}
