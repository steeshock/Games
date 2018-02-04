using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harder : MonoBehaviour {

	private bool hard;
	public GameObject detectClicks;
	void Update () {
		if (CubeJump.count_blocks > 0) {
			if (CubeJump.count_blocks % 7 == 0 && !hard) {
				print ("harder");
				hard = true;
				Camera.main.GetComponent <Animation> ().Play ("Harder");
				detectClicks.GetComponent <Animation> ().Play ("Harder2");
			} else if ((CubeJump.count_blocks % 7) -1 == 0 && hard) {
				hard = false;
				print ("easier");
				Camera.main.GetComponent <Animation> ().Play ("Easier");
				detectClicks.GetComponent <Animation> ().Play ("Easier2");
			}
		}
	}
}
