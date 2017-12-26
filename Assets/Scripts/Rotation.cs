using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float rotationSpeed = 100f;

    private bool rotateClockwise;

	public void Start () {
        int definer = Random.Range(0, 2);
        //Debug.Log(definer.ToString());

        if (definer == 1)
            rotateClockwise = true;
        else
            rotateClockwise = false;
	}
	
	public void Update () {

        if (rotateClockwise)
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        else
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }
}
