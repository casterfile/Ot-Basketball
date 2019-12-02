using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
	
	// Update is called once per frame
	public void UpdateChangeScene (string NameScene) {
		Application.LoadLevel(NameScene);
	}
}
