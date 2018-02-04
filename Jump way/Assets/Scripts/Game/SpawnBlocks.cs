using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour {

	public GameObject block, allCubes, diamond;
	private GameObject blockInst;
	private Vector3 blockPos;
	private float speed = 7f;
	private bool onPlace;

	void Start () {
		spawn ();
	}

	void Update () {
		if (blockInst.transform.position != blockPos && !onPlace)
			blockInst.transform.position = Vector3.MoveTowards (blockInst.transform.position, blockPos, Time.deltaTime * speed);
		else if (blockInst.transform.position == blockPos)
			onPlace = true;

		if (CubeJump.jump && CubeJump.nextBlock) {
			spawn ();

			onPlace = false;
		}
	}

	float RandScale () {
	
		float rand;

		if (Random.Range (0, 100) > 80)
			rand = Random.Range (1.2f, 2f);
		else
			rand = Random.Range (1.3f, 1.7f);
		return rand;
			

	}

	void spawn () {

		blockPos = new Vector3 (Random.Range (1f, 1.7f), Random.Range (-3.2f, 0.5f), -1.25f);
		blockInst = Instantiate (block, new Vector3 (5f, -6f, 0f), Quaternion.identity) as GameObject;
		blockInst.transform.localScale = new Vector3 (RandScale (), 0.5f, 2f);
		blockInst.transform.parent = allCubes.transform;
		if (CubeJump.count_blocks % 2 == 0 && CubeJump.count_blocks != 0) {
			GameObject diamondInst = Instantiate (diamond, new Vector3 (blockInst.transform.position.x, blockInst.transform.position.y + 0.5f, blockInst.transform.position.z), Quaternion.Euler (Camera.main.transform.eulerAngles)) as GameObject;
			diamondInst.transform.parent = blockInst.transform;
		}
	}
}
