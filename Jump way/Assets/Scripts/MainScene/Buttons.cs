using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

	void OnMouseUpAsButton () {
		switch (gameObject.name) {
		case "Restart":
			SceneManager.LoadScene ("main");
			break;
		case "Facebook":
			Application.OpenURL ("https//steeshock.ru");
			break;
		}
	}
}
