using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jingziqi : MonoBehaviour {
	
	private int turn = 1;
	private int[,] state = new int[3,3];
	private int[,] isClick = new int[3, 3];

	void Start()
	{
		Reset ();
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(300,150,80,50),"Reset")) Reset ();
		int result = check ();
		if(result == 1) GUI.Label (new Rect (300, 110, 200, 100), "O WINS!");
		if(result == 2) GUI.Label (new Rect (300, 110, 200, 100), "X WINS!");
		if(result == 3) GUI.Label (new Rect (300, 110, 200, 100), "Tied!");
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (GUI.Button (new Rect (10 + 50 * i, 10 + 50 * j, 50, 50), "")) {
					if (turn == 1) {
						state [i, j] = 1;
						turn = 2;
					} else if (turn == 2) {
						state [i, j] = 2;
						turn = 1;
					}
				}
				if (isClick [i, j] == 0) {
					if (state [i, j] == 1) {
						GUI.Button (new Rect (10 + 50 * i, 10 + 50 * j, 50, 50), "O");
						isClick[i,j] = 1;
					}
					if (state [i, j] == 2) {
						GUI.Button (new Rect (10 + 50 * i, 10 + 50 * j, 50, 50), "X");
						isClick[i,j] = 2;
					}
				} 
				else {
					if (isClick [i, j] == 1) {
						GUI.Button (new Rect (10 + 50 * i, 10 + 50 * j, 50, 50), "O");
						state [i, j] = 1;
					}
					if (isClick [i, j] == 2) {
						GUI.Button (new Rect (10 + 50 * i, 10 + 50 * j, 50, 50), "X");
						state [i, j] = 2;
					}
				}

			}
		}
	}

	void Reset()
	{
		turn = 1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				state [i, j] = 0;
				isClick [i, j] = 0;
			}
		}
	}
	int check(){
		for (int i = 0; i < 3; i++) {
			if (state [i, 0] == 1 && state [i, 0] == state [i, 1] && state [i, 0] == state [i, 2])
				return 1;
			if (state [i, 0] == 2 && state [i, 0] == state [i, 1] && state [i, 0] == state [i, 2])
				return 2;
		}
		for (int j = 0; j < 3; j++) {
			if (state [0, j] == 1 && state [0, j] == state [1, j] && state [1, j] == state [2, j])
				return 1;
			if (state [0, j] == 2 && state [0, j] == state [1, j] && state [1, j] == state [2, j])
				return 2;
		}
		if (state [1, 1] == 1 && state [0, 0] == state [1, 1] && state [1, 1] == state [2, 2])
			return 1;
		if (state [1, 1] == 2 && state [0, 0] == state [1, 1] && state [1, 1] == state [2, 2])
			return 2;
		
		if (state [1, 1] == 1 && state [0, 2] == state [1, 1] && state [1, 1] == state [2, 0])
			return 1;
		if (state [1, 1] == 2 && state [0, 2] == state [1, 1] && state [1, 1] == state [2, 0])
			return 2;
		int tie = 1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				if (state [i, j] == 0)
					tie = 0;
			}
		}
		if (tie == 1)
			return 3;
		return 0;
	}
}