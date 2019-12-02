using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IDwebCams : MonoBehaviour {

	public static RawImage rawimage;
	WebCamTexture webCamTexture;

	public Text webCamDisplayText;

	void Start ()
	{
		rawimage = GameObject.Find ("ImagePerson").GetComponent<RawImage>();

		WebCamDevice[] cam_devices = WebCamTexture.devices;
		// for debugging purposes, prints available devices to the console
		for (int i = 0; i < cam_devices.Length; i++) 
		{
			print ("Webcam available: " + cam_devices [i].name);
		}
		GoWebCam02 ();
	}


	//CAMERA 01 SELECT
	public void GoWebCam01()
	{
		WebCamDevice[] cam_devices = WebCamTexture.devices;
		// for debugging purposes, prints available devices to the console
		for (int i = 0; i < cam_devices.Length; i++) 
		{
			print ("Webcam available: " + cam_devices [i].name);
		}

		webCamTexture = new WebCamTexture(cam_devices[0].name, 480, 640, 30);
		rawimage.texture = webCamTexture;
		if(webCamTexture != null)
		{
			webCamTexture.Play();
			Debug.Log("Web Cam Connected : "+webCamTexture.deviceName + "\n");
		}    
		webCamDisplayText.text = "Camera Type: " + cam_devices [0].name.ToString();
	}
	//CAMERA 02 SELECT
	public void GoWebCam02()
	{
		WebCamDevice[] cam_devices = WebCamTexture.devices;
		// for debugging purposes, prints available devices to the console
		for (int i = 0; i < cam_devices.Length; i++) 
		{
			print ("Webcam available: " + cam_devices [i].name);
		}

		webCamTexture = new WebCamTexture(cam_devices[1].name, 480, 640, 30);
		rawimage.texture = webCamTexture;
		if(webCamTexture != null)
		{
			webCamTexture.Play();
			Debug.Log("Web Cam Connected : "+webCamTexture.deviceName + "\n");
		}
		webCamDisplayText.text = "Camera Type: " + cam_devices [1].name.ToString();
	}
}