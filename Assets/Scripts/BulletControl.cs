using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour {

	private Vector3 startingPosition { get; set; }

	public float Range { get; set; }
    public float Speed { get; set; }
    public int Damage { get; set; }

	// Use this for initialization
	void Start () 
	{
        startingPosition = transform.position;

        transform.up.Normalize();
        rigidbody2D.velocity = transform.up * 100;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (OutOfRange()) 
		{
			Destroy (gameObject);
		}
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            EnemyControl enemyControl = collider.gameObject.GetComponent("EnemyControl") as EnemyControl;
            enemyControl.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }


	private bool OutOfRange()
	{
		return 	this.gameObject.transform.position.x > startingPosition.x + Range ||
			this.gameObject.transform.position.x < startingPosition.x - Range ||
			this.gameObject.transform.position.y > startingPosition.y + Range ||
			this.gameObject.transform.position.y < startingPosition.y - Range;
	}
}
