using UnityEngine;
using System.Collections;

public class BackgroundPan : MonoBehaviour {

    public float panspeed = 5f;
    private bool pan = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (pan) { transform.position = transform.position + Vector3.right * Time.deltaTime * panspeed; }
    }

    public void stopBackgroundPan()
    {
        pan = false;
    }
}
