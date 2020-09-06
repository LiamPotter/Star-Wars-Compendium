using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour {

	private Animator animator;
	public Animator HomePanelAnimator;
	public bool HomePanelOpen = true;
	public bool LeftPanelClosed = true;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	public void ToggleLeftBar()
	{
		LeftPanelClosed = !LeftPanelClosed;
		animator.SetBool("MiddleOnly", LeftPanelClosed);
	}
	public void ToggleHomePanel()
	{
		HomePanelOpen = !HomePanelOpen;
		HomePanelAnimator.SetBool("Open", HomePanelOpen);
	}
}
