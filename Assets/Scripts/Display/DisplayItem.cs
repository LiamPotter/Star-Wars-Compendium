using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayItem : MonoBehaviour {

	public TextMeshProUGUI NameInput;

	public void Initialize(string name)
	{
		NameInput.text = name;
	}
}
