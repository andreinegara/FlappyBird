using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

	// Update is called once per frame
	void Update () {
		transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
		if (transform.position.x < -15){
			Destroy (gameObject);
		}
	}
}
