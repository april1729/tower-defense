using UnityEngine;
using System.Collections;

public class WaveScript : MonoBehaviour {
	private GameObject[] enemyArr;
	public int[] enemiesToMake; //Element n in this array is the number of enemies to make between seconds n and n+1;
	private float[] times; // an array full of times that enemies should be made.  this array is created from enemiesToMake
	private bool[] wasMade;
	public bool midWave=false;
	private float startTime=0f;
	public int wave=0; //set this to whatever wave this is a part of
	public bool isActive=false; //set this to true to start the wave.
	private WaveTrackingScript waveTrackingScript;
	private int numOfEnemies;
	public Object enemy;
	void Start()
	{
		//initialize the times array. this is the main thing that needs added with the update
		//count the total number of enemies to be made.  This might not actually be needed.
		numOfEnemies = 0;
		foreach (int i in enemiesToMake) {
			numOfEnemies+=i;		
		}

		times = new float[numOfEnemies];

		float curser = 0;
		int enemiesSpawned = 0;
		foreach(int i in enemiesToMake){
			for(int j=0; j<i; j++){
				times[enemiesSpawned]= curser+(((float)j+1)/ ((float)i+1));
				enemiesSpawned++;
			}
			curser=curser+1;
		}

		wasMade = new bool[times.Length];
		for (int i=0; i< times.Length; i++) {
			wasMade [i] = false;
				}
		Debug.Log (wasMade);
		int numSelectors = times.Length;
		enemyArr = new GameObject[numSelectors];
		waveTrackingScript = GetComponent<WaveTrackingScript> ();


	}
	// Update is called once per frame
	void Update () {
		Debug.Log(Time.fixedTime-startTime);
		if (midWave) {
						for (int i=0; i <= times.Length; i++) {
								if (wasMade [i] == false) {
										if (times [i] < Time.fixedTime - startTime) {
												enemyArr [i] = (GameObject)Instantiate ( enemy);//Resources.Load ("enemy"));
												enemyArr [i].transform.position = transform.position;
												wasMade [i] = true;
												waveTrackingScript.numEmemies++;
										}
								
								}
						}
				
				}
	}
	public void startWave(){

		midWave = true;
		startTime = Time.fixedTime;

	}
}
