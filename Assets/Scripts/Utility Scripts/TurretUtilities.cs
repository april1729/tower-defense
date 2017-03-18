using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

public static class TurretUtilities
{
    public static GameObject GetTargetedEnemy(GameObject turret, float range)
    {
        // Get all enemies in range
//        List<GameObject> enemiesInRange = (from enemy in GameObject.FindGameObjectsWithTag("Enemy")
//                                           where Vector3.Distance(turret.transform.position, enemy.transform.position) <= range
//                                           select enemy).ToList();
//        
//        // Sort by relative distance
//        enemiesInRange.Sort((e1, e2) => DistanceBetween(turret.transform, e1.transform).CompareTo(DistanceBetween(turret.transform, e2.transform)));
//
//        // Return the closest one
//        return enemiesInRange.Count > 0 ? enemiesInRange[0] : null;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float maxPriority = 0;
		GameObject target=null;
		foreach (GameObject i in enemies) {
			EnemyControl enemyScript=i.GetComponent<EnemyControl>();
			if (enemyScript!=null){
				if ((enemyScript.GetPriority()>maxPriority ) &&(range> DistanceBetween(turret.transform, i.transform))){
					target=i;
					maxPriority=enemyScript.GetPriority();
					}
				}
			}
		


		return target;
    }

    public static float DistanceBetween(Transform transform1, Transform transform2)
    {
        return Vector3.Distance(transform1.position, transform2.position);
    }

    

    
}
