using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelInstruction : MonoBehaviour {
	public float speed;

	public bool status;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (status) {
			transform.Rotate (Vector3.up, speed * 5 * Time.deltaTime);
		}
	}

	public void setStatus () {
		status = !status;
	}
}