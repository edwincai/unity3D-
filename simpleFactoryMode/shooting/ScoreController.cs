using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
	public int score;
	public static ScoreController _instance;
	public static ScoreController getInstance(){
		if (_instance == null)
			_instance = new ScoreController ();
		return _instance;
	}
	public void record(Diskdata dd){
		if (dd.color == Color.red) {
			score += 5;
		} else if (dd.color == Color.blue) {
			score += 10;
		} else if(dd.color == Color.black) 
			score += 20;
	}
	public void Reset(){
		score = 0;
	}
	public int getscore(){
		return score;
	}
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
