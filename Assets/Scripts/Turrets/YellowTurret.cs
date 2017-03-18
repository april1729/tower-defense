
//	Red Turret:
//		Very basic turret inteded Touch be the first TurretControl players have acces to.
//		
//		upgrade 1: Increase range.
//		upgrade 2: Increase firing rate.

using UnityEngine;
using System.Collections;

public class YellowTurret : MonoBehaviour, ITurret {



//	public int[] updrageCost1=[10,20,20,30];
//	public int[] upgradeCost2=[10,20,20,30];
//	public int timesUpgraded1=0;
//	public int timesUpgraded2=0;
	public void Upgrade1(){
		Debug.Log ("upgrade 1 Yellow turret");
	}


	
}