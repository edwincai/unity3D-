using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour {
	private static DiskFactory _instance;
	public static List<GameObject> free = new List<GameObject> ();
	public static List<GameObject> used = new List<GameObject> ();
	private int ruler = 1;
	//public GameObject disk;
	public static DiskFactory getInstance(){
		if (_instance == null)
			_instance = new DiskFactory ();
		return _instance;
	}

	public GameObject GetDisk(int ruler){
		if (free.Count == 0) {
			GameObject a_disk = Instantiate<GameObject> (Resources.Load<GameObject> ("Prefabs/RedDisk"));
			Diskdata dd = a_disk.GetComponent<Diskdata> ();
			Renderer render = a_disk.GetComponent<Renderer> ();
			render.material.color = getDiskColor (ruler);
			dd.color = render.material.color;
			dd.score = getDiskScore (dd.color);
			dd.transform.position = new Vector3 (-19, 1, 0);
			used.Add (a_disk);
			//要不要修改Adisk的屬性diskdata？
			return a_disk;
			// Created a new disk
		} 
		else {
			GameObject a_disk = free [0];
			free.RemoveAt (0);
			used.Add (a_disk);
			//要不要修改Adisk的屬性diskdata？
			return a_disk;
		}

	}

	public void FreeDisk(GameObject disk){
		for(int i = 0; i < used.Count;i++){
			if(used[i].transform.position == disk.transform.position){
				used.RemoveAt(i);
				disk.transform.position = new Vector3 (-19, 7, 0);
				//Diskdata dd = a_disk.GetComponent<Diskdata> ();
				//Renderer render = a_disk.GetComponent<Renderer> ();
				free.Add (disk);
				break;
			}
		}
		disk.transform.position = new Vector3(-19,0,0);
		used.Remove (disk);
		free.Add (disk);
	}

	public void moveDisk(){
		for (int i = 0; i < used.Count; i++) {
			Vector3 target = new Vector3 (150, used[i].transform.position.y, 0);
			if (used[i].transform.position == target)
				FreeDisk (used [i]);
			used [i].transform.position = Vector3.MoveTowards (used [i].transform.position, target, 5 * Time.deltaTime);
		}
	}
	private Color getDiskColor(int ruler){
		double num = Random.Range (1, 4);
		if (num < 2) {
			return Color.red;
		} else if (num > 2 && num < 3)
			return Color.blue;
		else
			return Color.black;
	}
	private int getDiskScore(Color color){
		if (color == Color.red)
			return 5;
		else if (color == Color.blue)
			return 10;
		else if (color == Color.black)
			return 20;
		else
			return 0;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
