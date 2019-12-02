using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public Image Picture;
	public RawImage RImage;
//	public GameObject DataTest;
//	public GameObject DataTest2;
	void Start () {
//		Picture = IDwebCams.rawimage;
		if (IDwebCams.rawimage.texture == null) {
			print ("Null RImage.texture = IDwebCams.rawimage.texture;");
		} else {
			RImage.texture = IDwebCams.rawimage.texture;
//			DataTest.GetComponent<MeshRenderer>().material.mainTexture = IDwebCams.rawimage.texture;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

