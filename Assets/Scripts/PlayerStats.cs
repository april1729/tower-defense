using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
	
	public static PlayerStats Instance;
	
	
	public int health;
	public int cash;

	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of PlayerStats!");
		}
		Instance = this;
	}
	
	public void Spend(int cost)
	{
		cash-=cost;
	}
	public void Earn(int reward)
	{
		cash += reward;
	}	
	public void TakeDamage(int damage)
	{
		health -= damage;
	}

	public int getHealth(){
		return health;
	}
	public int getCash(){
		return cash;
	}
	
}