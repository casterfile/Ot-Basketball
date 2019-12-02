using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcontroller : MonoBehaviour {

	Vector3 swipeDirection;
	bool isFire = false, isBallMoving = false;

	private Vector2 fingerDown;
	private Vector2 fingerUp;
	public bool detectSwipeOnlyAfterRelease = false;

	private float SWIPE_THRESHOLD = 50f;
	float LocationStartX,LocationStartY;
	float LocationSizeX,LocationSizeY;

	// Use this for initialization
	void Start () {
		LocationStartX = gameObject.transform.localPosition.x;
		LocationStartY = gameObject.transform.localPosition.y;

		LocationSizeX = gameObject.transform.localScale.x;
		LocationSizeY = gameObject.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		

		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fingerUp = touch.position;
				fingerDown = touch.position;
			}

			//Detects Swipe while finger is still moving
			if (touch.phase == TouchPhase.Moved)
			{
				if (!detectSwipeOnlyAfterRelease)
				{
					fingerDown = touch.position;
					checkSwipe();
				}
			}

			//Detects swipe after finger is released
			if (touch.phase == TouchPhase.Ended)
			{
				fingerDown = touch.position;
				checkSwipe();
			}
		}
		if (isFire == false) {
			transform.localPosition = new Vector3 (LocationStartX, LocationStartY, 0);
			transform.localScale = new Vector3 (LocationSizeX, LocationSizeY, 0);

		} else {
			if(gameObject.transform.localScale.x > 0.7f){
				gameObject.transform.localScale += new Vector3(-0.01F, -0.01F, 0);
			}
		}

	}

	void BallFire(float DataY , float DataX){
		if (isFire == true && isBallMoving == false) {
			isBallMoving = true;
			if (fingerDown.x - fingerUp.x > 0)//Right swipe
			{
				DataX = fingerUp.x;
			}
			else if (fingerDown.x - fingerUp.x < 0)//Left swipe
			{
				DataX = -fingerUp.x;
			}

			StartCoroutine(BallTimer(DataY,DataX));
		}
	}

	IEnumerator BallTimer(float DataY , float DataX)
	{
		print ("fingerDown.y: "+fingerDown.y);
		print ("fingerUp.y: "+fingerUp.y);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		Vector3 dir;
		float LocalDataY = fingerDown.y * 3;

		float LocalDataX = fingerUp.x* 3;// * 3;
		dir = new Vector3 (LocalDataX, LocalDataY, 0f);
		gameObject.GetComponent<Rigidbody2D> ().AddForce (fingerUp * 100);

		yield return new WaitForSeconds(2);
		gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		dir = new Vector3 (0f, -LocalDataY, 0f);
		gameObject.GetComponent<Rigidbody2D> ().AddForce (dir * 150);

		yield return new WaitForSeconds(1);

		isBallMoving = false;
		isFire = false;
	}

	void checkSwipe()
	{
		//Check if Vertical swipe
		if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
		{
			//Debug.Log("Vertical");
			if (fingerDown.y - fingerUp.y > 0)//up swipe
			{
				OnSwipeUp();
			}
			else if (fingerDown.y - fingerUp.y < 0)//Down swipe
			{
				OnSwipeDown();
			}
			fingerUp = fingerDown;
		}

		//Check if Horizontal swipe
		else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
		{
			//Debug.Log("Horizontal");
			if (fingerDown.x - fingerUp.x > 0)//Right swipe
			{
				OnSwipeRight();
			}
			else if (fingerDown.x - fingerUp.x < 0)//Left swipe
			{
				OnSwipeLeft();
			}
			print ("fingerDown.x"+ fingerDown.x +" - fingerUp.x "+ fingerUp.x);
			fingerUp = fingerDown;
		}

		//No Movement at-all
		else
		{
			//Debug.Log("No Swipe!");
		}
	}

	float verticalMove()
	{
		return Mathf.Abs(fingerDown.y - fingerUp.y);
	}

	float horizontalValMove()
	{
		return Mathf.Abs(fingerDown.x - fingerUp.x);
	}

	//////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
	void OnSwipeUp()
	{
		Debug.Log("Swipe UP");
//		Debug.Log("verticalMove: "+ verticalMove() + "|| horizontalValMove: "+ horizontalValMove());
		isFire = true;
		BallFire (verticalMove(),0);
	}

	void OnSwipeDown()
	{
		Debug.Log("Swipe Down");
//		Debug.Log("verticalMove: "+ verticalMove() + "|| horizontalValMove: "+ horizontalValMove());
//		isFire = true;
//		BallFire (verticalMove(),horizontalValMove());
	}

	void OnSwipeLeft()
	{
		Debug.Log("Swipe Left");
		Debug.Log("verticalMove: "+ verticalMove() + "|| horizontalValMove: "+ horizontalValMove());
		isFire = true;
		BallFire (verticalMove(),-400);
	}

	void OnSwipeRight()
	{
		Debug.Log("Swipe Right");
//		Debug.Log("verticalMove: "+ verticalMove() + "|| horizontalValMove: "+ horizontalValMove());
		isFire = true;
		BallFire (verticalMove(),400);
	}
}
