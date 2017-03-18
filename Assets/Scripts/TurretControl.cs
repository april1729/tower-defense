using UnityEngine;
using System.Collections;

public class TurretControl : MonoBehaviour {

	public GameObject Bullet;
	public int cost;
	public float shotInterval = 3f;
	public float timeOfLastShot;
	public float range = 10;
    public int bulletSpeed = 5;
    public int bulletDamage = 30;
	public int sellPrice=29;
	ITurret iturret;

	GameObject upgradeObject;
	TurretUpgradeControl turretUpgrade;
	// Use this for initialization
	void Start () 
	{
		iturret= (ITurret)gameObject.GetComponent(typeof(ITurret));
		upgradeObject = GameObject.Find ("TurretUpgradeObject");
		turretUpgrade = upgradeObject.GetComponent<TurretUpgradeControl> ();
		timeOfLastShot = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // aiming
        GameObject enemy = TurretUtilities.GetTargetedEnemy(gameObject, range);
        if(enemy != null)
        {
            Utilities.LookAt2D(gameObject.transform, enemy.transform);

            // shooting
			if (Time.time - timeOfLastShot > shotInterval)
            {
				timeOfLastShot = Time.time;
                GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;

                BulletControl bulletControl = bullet.GetComponent("BulletControl") as BulletControl;
                bulletControl.Range = range;
                bulletControl.Speed = bulletSpeed;
                bulletControl.Damage = bulletDamage;
            }
        }
	}
	void OnMouseDown(){
		Debug.Log ("asda");
		turretUpgrade.StartUpgrading (gameObject);
	}

	public void Upgrade1(){
		iturret.Upgrade1 ();
	}
	public void Upgrade2(){
	}
	public void Sell(){
		PlayerStats.Instance.Earn (sellPrice);
		Destroy (gameObject);
	}
}
