using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mygame;

public class UserInterface : MonoBehaviour {

	Singlton my;
	IUserActions action;
	float width, height;
	// Use this for initialization
	void Start () {
		my = Singlton.getInstance();
		action = Singlton.getInstance () as IUserActions;
	}

	void OnGUI(){
		width = Screen.width / 12;
		height = Screen.height / 12;
		if (my.state == State.WIN) {
			if (GUI.Button (new Rect (300, 100, width, height), "Win")) {
				action.restart();
			}
		}
		if (my.state == State.LOSE) {
			if (GUI.Button (new Rect (300, 100, width, height), "Lose")) {
				action.restart();
			}
		}
		if (my.state == State.BSTART || my.state == State.BEND) {
			if (GUI.Button(new Rect(300, 50, width,height), "Go")) {
				action.moveBoat();
			}
			if (GUI.Button(new Rect(50, 100, width, height), "D On")) {
				action.devilSOnB();
			}
			if (GUI.Button(new Rect(150, 100, width, height), "P On")) {
				action.priestSOnB();
			}
			if (GUI.Button(new Rect(500, 100, width, height), "D On")) {
				action.devilEOnB();
			}
			if (GUI.Button(new Rect(600, 100, width, height), "P On")) {
				action.priestEOnB();
			}
			if (GUI.Button(new Rect(250, 200, width, height), "L Off")) {
				action.offBoatL();
			}
			if (GUI.Button(new Rect(350, 200, width, height), "R Off")) {
				action.offBoatR();
			}
		}
	}
}
