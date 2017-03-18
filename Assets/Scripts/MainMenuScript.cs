using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	public int selGridInt = -1;
	public string[] selStrings = new string[] {"Start", "Shop"};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	switch (selGridInt) {
				case -1:
						break;
				case 0:
						Application.LoadLevel ("levelSelect");
						break;
				case 1:
						Application.LoadLevel ("scene");
			break;
				}
	}

	void OnGUI()
{		


	GUILayout.BeginArea(new Rect(Screen.width*.4f, Screen.height/2f, Screen.width*.2f, Screen.height));

	selGridInt = GUILayout.SelectionGrid(selGridInt, selStrings, 1);
	GUILayout.EndArea ();
}
}

