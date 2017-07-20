using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	//如何調用scorecontroller？
	//如何從diskFactory獲得飛碟？
	//bool newDisk;
	private int ruler;
	private DiskFactory factory;
	private GameObject currentDisk;
	private ScoreController score_controller;
	private GameObject cam;
	private GameObject plane;
	//獲取round數
	void Start () {
		ruler = 1;
		score_controller = ScoreController.getInstance ();
		plane = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Plane"));
		cam = GameObject.Find("Main Camera");
		factory = DiskFactory.getInstance ();
		//score_controller = this.GetComponent<ScoreController> ();

	}
	
	// Update is called once per frame
	void Update () {
		//if(發生碰撞)
		//調用ScoreController的record函數
		double i = Random.Range(0,10);
		if(i < 1)
			currentDisk = factory.GetDisk(ruler);
		factory.moveDisk ();
		//newDisk = ifNewDisk()

		//factory.checkVisible();
	}
	void OnGUI(){
		GUI.Box(new Rect(0, 0, 80, 40), "Round " + ruler);
		GUI.Box(new Rect(0,40,80,40),"Score: "+ score_controller.getscore());
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 mp = Input.mousePosition;
			Camera ca = cam.GetComponent<Camera> ();
			Ray ray = ca.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				GameObject get_hit = hit.collider.gameObject;
				if (get_hit.tag.Contains ("Finish")) {
					score_controller.record (get_hit.GetComponent<Diskdata> ());
					factory.FreeDisk (get_hit);
				}
			}
		}
	}
}
