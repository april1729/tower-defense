using UnityEngine;
using System.Collections;

public class SideBarControl : MonoBehaviour {
	string healthStr;
	private Texture[] towerButtomImages;
	public GameObject[] towerObjects;
	int selGridInt = 0;
	private GUITexture tex; 
	private bool placing=false;
	private int[] towerCost;
	private int health;
	private int cash;
	private bool fastForward=false;
	private TurretPlacementController turretPlacer;

	// Use this for initialization
	void Start () {
			towerButtomImages = new Texture[towerObjects.Length];
			towerCost = new int[towerObjects.Length];
			for (int i=0; i<towerObjects.Length; i++) {
					TurretControl turretControl = towerObjects [i].GetComponent<TurretControl> ();
					towerCost [i] = turretControl.cost;
			}
		}

	
	// Update is called once per frame
	void Update () {
		health=PlayerStats.Instance.getHealth();
		cash=PlayerStats.Instance.getCash ();
	 
	}


	void OnGUI()
	{		
		for (int i=0; i<towerObjects.Length ; i++) {
			tex = towerObjects[i].GetComponent<GUITexture> (); // we are accessing the SpriteRenderer that is attached to the Gameobject
			towerButtomImages [i] = tex.texture; // set the sprite to sprite1
		
		}
		GUILayout.BeginArea(new Rect(Screen.width*.8f, 0, Screen.width*.2f, Screen.height));
		GUILayout.BeginVertical("box");

		GUILayout.Box("heath: "+health.ToString()+"\n"+"cash: "+cash.ToString()) ;

		if (IsPlacing () == false) {
						selGridInt = -1; //OnGui is called every timestep, so this is to tell if the button is clicked.
				}
		selGridInt = GUILayout.SelectionGrid (selGridInt, towerButtomImages, 1,GUILayout.MaxHeight(Screen.height*0.3f));
		if (selGridInt != -1) {
			if (cash-towerCost[selGridInt]<0){
				selGridInt=-1;
			}
			else{
				PlaceTurret(towerObjects[selGridInt]);
			}
		}
		fastForward = GUILayout.Toggle(fastForward, "fast forward");
		switch (fastForward) {
		case true:
			Time.timeScale=3.0f;
			break;
		case false:
			Time.timeScale=1.0f;
			break;
				}
		GameObject WaveObject = GameObject.Find ("EnemySpawnObject");
		WaveTrackingScript waveScript = WaveObject.GetComponent<WaveTrackingScript> ();
		if(waveScript.midWave==false){
			if (GUILayout.Button ("Start Wave")) {
				waveScript.startWave();
			}
		}
		GUILayout.Box(selGridInt.ToString()) ;
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	}
	void PlaceTurret(GameObject turret){
		GameObject TurretPlacementObject = GameObject.Find ("TurretPlacementObject");
		turretPlacer = TurretPlacementObject.GetComponent<TurretPlacementController> ();

		turretPlacer.StartPlacing (turret);
	}
	bool IsPlacing(){
		GameObject TurretPlacementObject = GameObject.Find ("TurretPlacementObject");
		turretPlacer = TurretPlacementObject.GetComponent<TurretPlacementController> ();
		
		return turretPlacer.placing;

}
}
