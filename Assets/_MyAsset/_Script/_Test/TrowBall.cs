using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrowBall : MonoBehaviour {

	private float power = 280.0f;
	float slX;
	float slY;
	float slZ;
	private Vector3 startPos;
	bool isSetlocation = false;
	public Text ScoreData;
	int ScoreInt;
	public GameObject yDirectionLimit;

	void Start(){
		ScoreInt = 0;
		slX = gameObject.transform.localPosition.x;
		slY = gameObject.transform.localPosition.y;
		slZ = gameObject.transform.localPosition.z;
	}

	void Update(){
		ScoreData.text = ScoreInt+"";
//		if(gameObject.transform.position.y >= yDirectionLimit.transform.localPosition.y-100 ){
//			float x = gameObject.transform.position.x;
//			float y = yDirectionLimit.transform.position.y-1000;
//			float z = gameObject.transform.position.z;
//			gameObject.transform.position = new Vector3(x,y,z);
//			print ("He;");
//		}
	}

	void OnMouseDown() {
		StopCoroutine(ReturnBall());
		startPos = Input.mousePosition;
		startPos.z = transform.position.z - Camera.main.transform.position.z;
		startPos = Camera.main.ScreenToWorldPoint(startPos);
	}
	void OnMouseUp() {
		var endPos = Input.mousePosition;
		endPos.z = transform.position.z - Camera.main.transform.position.z;
		endPos = Camera.main.ScreenToWorldPoint(endPos);

		var force = endPos - startPos;
//		force.x = force.magnitude;
		force.y = 35;//force.magnitude;
		force.z = 50;

//		
//		force.Normalize();

		GetComponent<Rigidbody>().AddForce(force * power);
//		StartCoroutine(ReturnBall());
	}

	IEnumerator ReturnBall() {
		yield return new WaitForSeconds(3);
		transform.localPosition = new Vector3(slX,slY,slZ);//Vector3.zero;
		GetComponent<Rigidbody>().velocity = Vector3.zero;

	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "HitBox")
		{
			StopCoroutine(ReturnBall());
			transform.localPosition = new Vector3(slX,slY,slZ);//Vector3.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			print ("Score");
			ScoreInt++;
		}

		if(col.gameObject.tag == "grid")
		{
			StopCoroutine(ReturnBall());
			transform.localPosition = new Vector3(slX,slY,slZ);//Vector3.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			print ("No Score");
			ScoreInt--;
		}
	}

	private void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "HitBox")
		{
			StopCoroutine(ReturnBall());
			transform.localPosition = new Vector3(slX,slY,slZ);//Vector3.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			print ("Score");
			ScoreInt++;
		}

		if(col.gameObject.tag == "grid")
		{
			StopCoroutine(ReturnBall());
			transform.localPosition = new Vector3(slX,slY,slZ);//Vector3.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			print ("No Score");
			ScoreInt--;
		}
	}

}

