using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour {

	private Animator animator;
	private bool MiddleOnly =true;
	public Animator HomePanelAnimator;
	[HideInInspector]
	public bool HomePanelOpen = true;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	public void ToggleLeftBar()
	{
		MiddleOnly = !MiddleOnly;
		animator.SetBool("MiddleOnly", MiddleOnly);
	}
	public void ToggleHomePanel()
	{
		HomePanelOpen = !HomePanelOpen;
		HomePanelAnimator.SetBool("Open", HomePanelOpen);
	}
}
