using UnityEngine;
using System.Collections;

public class TurretUpgradeControl : MonoBehaviour {
	public bool upgrading=false;
	public Texture[] towerButtonImages;
	GameObject upgradingTurret;
	TurretControl turretControl;
	void Start () {

	}

	void Update () {
//		if (upgrading) {
//			if (Input.GetButtonDown("Fire1")) {
//				if(Input.mousePosition.y>Screen.height*0.15f){
//					upgrading=false;
//				}
//			}
//		}



	}
	
	void OnGUI() {	
		if (upgrading) {
			GUILayout.BeginArea (new Rect (0, Screen.height * .85f, Screen.width * .9f, Screen.height * 0.15f));
			GUILayout.BeginHorizontal ("box");
		
			GUILayout.Box ("Upgrades!!!");
			if (GUILayout.Button("Upgrade 2: \n "+20)){
				turretControl.Upgrade2();
				upgrading=false;

			}
			if(GUILayout.Button("Upgrade 1: \n "+20)){
				turretControl.Upgrade1();
				upgrading=false;
			}
			if(GUILayout.Button("Sell: \n "+turretControl.sellPrice.ToString())){
				turretControl.Sell();
				upgrading=false;
			}


			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		}
	}
	public void StartUpgrading(GameObject turret){
		upgrading = true;
		upgradingTurret = turret;
		turretControl = upgradingTurret.GetComponent<TurretControl> ();

	}
}