using UnityEngine;
using System.Collections;

public class PanBoundaries : MonoBehaviour {

    public Transform target;
    private Vector3 position;

	// Use this for initialization
	void Start () {
        position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = position + target.position;
	}
}
