using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTest : MonoBehaviour {
	public Text Info;
	public static bool isTablet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (IsTablet () == true) {
			print ("IPad");
			Info.text = "Tablet/IPad";
			isTablet = true;
			StartCoroutine(DelayStart(0.0f));
		} else {
			print ("IPhone");
			Info.text = "Mobile Phone";
			isTablet = false;
			StartCoroutine(DelayStart(0.0f));
		}
	}

	public static bool IsTablet(){

		float ssw;
		if(Screen.width>Screen.height){ssw=Screen.width;}else{ssw=Screen.height;}

		if(ssw<800) return false;

		if(Application.platform==RuntimePlatform.Android || Application.platform==RuntimePlatform.IPhonePlayer){
			float screenWidth = Screen.width / Screen.dpi;
			float screenHeight = Screen.height / Screen.dpi;
			float size = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
			if(size >= 6.5f) return true;
		}

		return false;
	}

	IEnumerator DelayStart(float Delay)
	{
		
		yield return new WaitForSeconds(Delay);
		if (IsTablet () == true) {
			Application.LoadLevel ("Scene01_Intro");
		} else {
			Application.LoadLevel ("Scene01_Intro_Mobile");
		}
	}
}
