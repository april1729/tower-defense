using UnityEngine;
using System.Collections;

public class WaveTrackingScript : MonoBehaviour {
	public bool midWave=false;
	public int currentWave=0; //set this to whatever wave this is a part of
	private float startTime=0f;
	private WaveScript[] waves;
	private float waveDuration;
	public int numEmemies=0;
	void Start()
	{
		waves = GetComponents<WaveScript> ();
	}
	// Update is called once per frame
	// just checks to see if the wave is over
	void Update () {
		if (numEmemies == 0 && midWave == true && Time.fixedTime-startTime>1) {
			endWave();
		}
	}




	public void startWave(){
		midWave = true;
		startTime = Time.fixedTime;
		foreach (WaveScript i in waves) {
			if(i.wave==currentWave){
				i.startWave();
			}
		}
	}



	public void endWave(){
		midWave = false;
		currentWave++;
	}

}
