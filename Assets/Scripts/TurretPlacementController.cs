using UnityEngine;
using System.Collections;


public class TurretPlacementController : MonoBehaviour {
	public Sprite green;
	public Sprite red;
	public bool placing;

	private GameObject tower;
	private SpriteRenderer sprite;
	TurretControl turretControl;

	// Use this for initialization
	void Start () {
		sprite=GetComponent<SpriteRenderer>();
	
	}
	void SetSpriteScale(){
		BoxCollider2D collider = GetComponent<BoxCollider2D> ();
		float scale = 2*turretControl.range / (collider.bounds.size.x);
		transform.localScale = new Vector3(scale*transform.localScale.x,scale*transform.localScale.y,0);
	}
	
	// Update is called once per frame
	void Update () {
		UpdateSprite ();
		UpdatePosition ();
		PlaceTower (tower);
	}
	void UpdateSprite(){
		if (placing == false) {
				sprite.sprite = null;
		} else {
				if (CanPlace ()) {
						sprite.sprite = green;
				} else {
						sprite.sprite = red;
				}
			}
		}
	void UpdatePosition(){
				Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				transform.position = new Vector3 (mousePos.x, mousePos.y, 0);
		}
	bool CanPlace(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Collider2D[] hitColliders=Physics2D.OverlapCircleAll(mousePos, 0.1f);
		if (hitColliders.Length<2){
			return true;
		}
		else{
			return false;
		}

	}
	public void StartPlacing(GameObject towertemp){
		if (placing == false) {
						placing = true;
						tower = towertemp;
						turretControl = tower.GetComponent<TurretControl> ();
						SetSpriteScale ();
				}
		}

	private void PlaceTower(GameObject tower){
		
		if (Input.GetButtonDown("Fire1") && placing && CanPlace()){
		
				
				placing=false;
				
				if(Input.mousePosition.x<Screen.width*0.9){
				Vector3 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);

				GameObject.Instantiate(tower,new Vector3(mousePos.x,mousePos.y,0),Quaternion.identity);
				PlayerStats.Instance.Spend(turretControl.cost);
				}
			}
		}
		

}
