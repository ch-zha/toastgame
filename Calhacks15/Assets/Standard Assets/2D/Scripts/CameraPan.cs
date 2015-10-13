using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

    public Transform target;
    public float camera_spd;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate ()
    {
        float targetx = target.position.x;
        float  targety = target.position.y;

        transform.position = new Vector3 (targetx, targety, -10);
    }
}
