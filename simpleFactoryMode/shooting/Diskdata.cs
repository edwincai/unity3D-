using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diskdata : MonoBehaviour {
	public Vector3 size;
	public Color color;
	public float speed;
	public int score;
	public static Diskdata getDiskData(Vector3 msize, Color mcolor, float mspeed, int mscore){
		Diskdata disk = new Diskdata ();
		disk.size = msize;
		disk.color = mcolor;
		disk.speed = mspeed;
		disk.score = mscore;
		return disk;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
