using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {
	public static List<GameObject> free = new List<GameObject>();
	public static List<GameObject> used = new List<GameObject>();
	private static Factory _instance;
	public static Factory getInstance(){
		if (_instance == null)
			_instance = new Factory ();
		return _instance;
	}

	public void placeAttackMark(Vector3 postion){
		GameObject t;
		if (free.Count == 0)
			t = Instantiate<GameObject> (Resources.Load<GameObject> ("Prefabs/Cylinder"),Vector3.zero,Quaternion.identity);
		else {
			t = free [0];
			free.Remove (t);
		}
		used.Add (t);
		t.transform.position = postion;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
