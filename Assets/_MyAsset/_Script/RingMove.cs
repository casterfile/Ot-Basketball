using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour {
	private Transform ItemTargetStart, ItemTargetEnd;

	private float speed = 10;
	private float resize = 100;
	private float TotalSpeed, TotalSpeedTemp;
	float stepGoingBack,step;
	bool isStartMove = true;

	// Use this for initialization
	void Start () {
		isStartMove = true;
		ItemTargetStart = GameObject.Find ("ItemTargetStart").GetComponent<Transform>();
		ItemTargetEnd = GameObject.Find ("ItemTargetEnd1").GetComponent<Transform>();

		//transform.position = new Vector2(ItemTargetStart.position.x, ItemTargetStart.position.y);
		TotalSpeed = (Screen.width / 300.0f) * speed;
		TotalSpeedTemp = TotalSpeed;
	}
	
	void Update () {
		TotalSpeed =  TotalSpeedTemp; //(GameController.ScoreCount * 10) +
		step = TotalSpeed * Time.deltaTime;
		stepGoingBack = TotalSpeedTemp * Time.deltaTime;



		if (isStartMove == true) {
			transform.position = Vector3.MoveTowards (transform.position, ItemTargetEnd.position, step);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, ItemTargetStart.position, step);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "ItemTargetStart")
		{
			isStartMove = true;
		}

		if(col.gameObject.name == "ItemTargetEnd1")
		{
			isStartMove = false;
		}
	}

	private void OnTriggerEnter(Collider col){
		if(col.gameObject.name == "ItemTargetStart")
		{
			isStartMove = true;
		}

		if(col.gameObject.name == "ItemTargetEnd1")
		{
			isStartMove = false;
		}
	}
}
