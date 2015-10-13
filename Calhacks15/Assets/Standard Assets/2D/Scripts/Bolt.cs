using UnityEngine;
using System.Collections;

public class Bolt : MonoBehaviour {

    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
        if (timer > 1.5)
        {
            GameObject.Destroy(gameObject);
        } else
        {
            timer += Time.deltaTime;
        }

	}
}
