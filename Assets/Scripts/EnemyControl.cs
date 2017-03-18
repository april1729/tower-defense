using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour 
{
    HealthBar healthBar;
	public Sprite[] sprites;
    public int originalHealth { get; set; }
    public int health { get; set; }
	public int damage=1;
	public int cashReward=1;
	private float startTime;
	public float speed=5;

	private Vector2 oldPosition;

	private SpriteRenderer sprite;
	// Use this for initialization
	void Start () 
    {
        health = originalHealth = 100;
		startTime = Time.fixedTime;
        healthBar = gameObject.GetComponent("HealthBar") as HealthBar;
        healthBar.Value = healthBar.Max = health;
        healthBar.Min = 0;

		oldPosition=new Vector2(0,0);

		sprite=GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        Camera mainCamera = Camera.allCameras[0];
		healthBar.pos = mainCamera.WorldToScreenPoint (transform.position - new Vector3(1F, 16));

		UpdateSprite ();
	}

	void UpdateSprite (){
		int spriteNum=Mathf.RoundToInt((Mathf.Rad2Deg*Mathf.Atan2(oldPosition.x-transform.position.x,oldPosition.y-transform.position.y))/45);
		spriteNum *= -1;
		spriteNum -= 2;
		if (spriteNum < 0) {
			spriteNum += 8;
		}
		sprite.sprite=sprites[spriteNum]; 
		oldPosition.x=transform.position.x;
		oldPosition.y=transform.position.y;

	
	}

    public void TakeDamage(int damage)
    {
        health = System.Math.Max(health - damage, 0);
        healthBar.Value = health;


        if(health <= 0)
        {
			PlayerStats.Instance.Earn (cashReward);
            Destroy(gameObject);
			GameObject WaveObject = GameObject.Find ("EnemySpawnObject");
			WaveTrackingScript waveScript = WaveObject.GetComponent<WaveTrackingScript> ();
			waveScript.numEmemies--;

        }
    }
	void octopusMissionComplete(){
		PlayerStats.Instance.TakeDamage (damage);
		Destroy (gameObject);
		GameObject WaveObject = GameObject.Find ("EnemySpawnObject");
		WaveTrackingScript waveScript = WaveObject.GetComponent<WaveTrackingScript> ();
		waveScript.numEmemies--;
	}
	public float GetPriority(){
		return (Time.fixedTime-startTime)/speed;
	}
}
