using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mygame;

public class GenGameObject : MonoBehaviour {
	Stack<GameObject> priests_start = new Stack<GameObject>();
	Stack<GameObject> priests_end = new Stack<GameObject>();
	Stack<GameObject> devils_start = new Stack<GameObject>();
	Stack<GameObject> devils_end = new Stack<GameObject>();

	GameObject[] boat = new GameObject[2];
	GameObject boat_obj;
	public float speed = 10f;

	Singlton my;

	Vector3 shoreStartPos = new Vector3(7, -2, 0);
	Vector3 shoreEndPos = new Vector3(-7, -2, 0);
	Vector3 boatStartPos = new Vector3(-2.5f, -2, 0);
	Vector3 boatEndPos = new Vector3(2.5f, -2, 0);

	float gap = 0.6f;
	Vector3 priestStartPos = new Vector3(-7, 0, 0);
	Vector3 priestEndPos = new Vector3(7, 0, 0);
	Vector3 devilStartPos = new Vector3(-9, 0, 0);
	Vector3 devilEndPos = new Vector3(5, 0, 0);

	void setCharacterPositions(Stack<GameObject> stack, Vector3 pos) {
		GameObject[] array = stack.ToArray();
		for (int i = 0; i < stack.Count; ++i) {
			array[i].transform.position = new Vector3(pos.x + gap * i, pos.y, pos.z);
		}
	}
	// Use this for initialization
	void Start () {
		my = Singlton.getInstance();  
		my.setGenGameObject(this);
		loadSource ();
	}

	void loadSource(){
		Instantiate(Resources.Load("Prefabs/Shore"), shoreStartPos, Quaternion.identity);
		Instantiate (Resources.Load ("Prefabs/Shore"), shoreEndPos, Quaternion.identity);
		boat_obj = Instantiate(Resources.Load("Prefabs/Boat"), boatStartPos, Quaternion.identity) as GameObject;   
		for (int i = 0; i < 3; i++) {  
			priests_start.Push(Instantiate(Resources.Load("Prefabs/Priest")) as GameObject);  
			devils_start.Push(Instantiate(Resources.Load("Prefabs/Devil")) as GameObject);  
		}
		Instantiate (Resources.Load ("Prefabs/Directional Light"));
	}
	int BoatSpace(){
		int num = 0;
		for (int i = 0; i < 2; i++) {
			if (boat [i] == null) {
				num++;
			}
		}
		return num;
	}
	void getOnTheBoat(GameObject obj){
		obj.transform.parent = boat_obj.transform;
		if (BoatSpace () != 0) {
			if (boat [0] == null) {
				boat [0] = obj;
				obj.transform.localPosition = new Vector3 (-0.5f, 1, 0);
			} else {
				boat [1] = obj;
				obj.transform.localPosition = new Vector3 (0.5f, 1, 0);
			}
		}
	}
	public void moveBoat(){
		if (BoatSpace () != 2) {
			if (my.state == State.BSTART) {  
				my.state = State.BSEMOVING;  
			}  
			else if (my.state == State.BEND) {  
				my.state = State.BESMOVING;  
			}  
		}
	}
	public void getOffTheBoat(int side){
		if (boat[side] != null) {
			boat [side].transform.parent = null;
			if (my.state == State.BEND) {
				if (boat[side].tag == "Priest") {
					priests_end.Push(boat[side]);
				}
				else if (boat[side].tag == "Devil") {
					devils_end.Push(boat[side]);
				}
			}
			else if (my.state == State.BSTART) {
				if (boat[side].tag == "Priest") {
					priests_start.Push(boat[side]);
				}
				else if (boat[side].tag == "Devil") {
					devils_start.Push(boat[side]);
				}
			}
			boat[side] = null;
		}
	}
	public void priestStartOnBoat(){
		if (my.state == State.BSTART && priests_start.Count != 0) {
			getOnTheBoat (priests_start.Pop ());  
		}
	}
	public void priestEndOnBoat() {
		if (my.state == State.BEND && priests_end.Count != 0) {
			getOnTheBoat (priests_end.Pop ());  
		}
	}
	public void devilStartOnBoat(){
		if (my.state == State.BSTART && devils_start.Count != 0) {
			getOnTheBoat (devils_start.Pop ());  
		}
	}
	public void devilEndOnBoat(){
		if (my.state == State.BEND && devils_end.Count != 0) {
			getOnTheBoat (devils_end.Pop ());
		}
	}
	public void check(){
		if (priests_end.Count != 0) {
			if (devils_end.Count > priests_end.Count)
				my.state = State.LOSE;
		}
		if (priests_start.Count != 0) {
			if (devils_start.Count > priests_start.Count)
				my.state = State.LOSE;
		}
		if (devils_end.Count == 3 && priests_end.Count == 3)
			my.state = State.WIN;
	}

	// Update is called once per frame
	void Update () {
		setCharacterPositions (priests_start, priestStartPos);
		setCharacterPositions (priests_end, priestEndPos);
		setCharacterPositions (devils_start, devilStartPos);
		setCharacterPositions (devils_end, devilEndPos);
		if (my.state == State.BSEMOVING) {
			boat_obj.transform.position = Vector3.MoveTowards(boat_obj.transform.position, boatEndPos, speed*Time.deltaTime);
			if (boat_obj.transform.position == boatEndPos) {
				my.state = State.BEND;
			}
		}
		else if (my.state == State.BESMOVING) {
			boat_obj.transform.position = Vector3.MoveTowards(boat_obj.transform.position, boatStartPos, speed*Time.deltaTime);
			if (boat_obj.transform.position == boatStartPos) {
				my.state = State.BSTART;
			}
		}
		else check();
	}
}
