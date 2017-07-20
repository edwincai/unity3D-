using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
	private Factory myFactory;
	public GameObject Cam;
	// Use this for initialization
	void Start () {
		myFactory = Factory.getInstance ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 mp = Input.mousePosition;

			Camera ca = Cam.GetComponent<Camera>();
			Ray ray = ca.ScreenPointToRay(mp);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject.tag.Contains("Finish"))
				{
					print(mp);
					myFactory.placeAttackMark(hit.point);
				}
			}
		}
	}
}
