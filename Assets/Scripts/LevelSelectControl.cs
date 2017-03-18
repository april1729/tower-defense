using UnityEngine;
using System.Collections;

public class LevelSelectControl : MonoBehaviour {
	public Texture[] levels;
	public Texture right;
	public Texture left;
	private Texture[] gridTex;
	private int selGridInt = -1;
	private float scrollInt=0;
	public string[][] gridStr;
	public int world=0;
	// Use this for initialization
	void Start () {
//		gridTex = new Texture[levels.Length+2*(levels.Length/3)];
//		for(int i=0; i<gridTex.Length; i++){
//			if (i%5==0){
//				gridTex[i]=left;
//			}
//			else if(i%5==4){
//				gridTex[i]=right;
//			}
//			else{
//				gridTex[i]=levels[i-1-2*(i/5)];
//			}
//		}
		gridStr = new string[2][];
		gridStr [0] = new string[]{"0-1","0-2","0-1","0-2","0-1","0-2","0-1","0-2"};
		gridStr [1] = new string[]{"1-1","1-2","1-3","1-4"};

	}
	
	// Update is called once per frame
	void Update () {
		}
	void startLevel(int level){
		string levelName = "level" + world.ToString()+"-"+level.ToString ();
		Application.LoadLevel (levelName);
	}

	void OnGUI()
	{		
		
		
		GUILayout.BeginArea(new Rect(Screen.width*(scrollInt), .3f*Screen.height, Screen.width*(levels.Length/3), 0.7f*Screen.height));
		GUILayout.BeginHorizontal ();

		if (GUILayout.Button ("<--")) {
						world -= 1;
				}

		selGridInt = GUILayout.SelectionGrid(selGridInt, gridStr[world],6,GUILayout.Height(0.7f*Screen.height));
		if (selGridInt > -1) {
			startLevel(selGridInt+1);
		}
		if (GUILayout.Button ("-->")) {
			world += 1;
		}		
		GUILayout.EndHorizontal();
		GUILayout.EndArea ();

	}
}
