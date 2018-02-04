using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameArragement : MonoBehaviour
{

    public GameObject buttons, m_cube, cubes, block, spawn_blocks, diamonds;
    public Text playTxt, gameName, study, record;
    private bool clicked;
    public GameObject[] _cubes;

    void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(delCubes());
            clicked = true;
            playTxt.gameObject.SetActive(false);
			study.gameObject.SetActive (true);
			record.gameObject.SetActive (true);
			diamonds.gameObject.SetActive (true);
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().checkPos = -160f;
            m_cube.GetComponent<Animation>().Play("StartGameCube");
            m_cube.transform.localScale = new Vector3(1f, 1f, 1f);
            cubes.GetComponent<Animation>().Play("CubesPosition");
            StartCoroutine(cubeToBlock());
		} else if (clicked && study.gameObject.activeSelf)
			study.gameObject.SetActive (false);
    }

    IEnumerator delCubes ()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(_cubes[i]);
        }
		spawn_blocks.GetComponent<SpawnBlocks> ().enabled = true;
    }

    IEnumerator cubeToBlock()
    {
        yield return new WaitForSeconds(m_cube.GetComponent<Animation>().clip.length);
        block.GetComponent<Animation>().Play();

		m_cube.AddComponent <Rigidbody> ();
    }
}
