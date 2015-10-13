using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour {

    public Vector3 target;
    public LayerMask layer;
    private float timer;
    private Collider2D collide;

	// Use this for initialization
	void Start () {
        timer = 0;
        collide = gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > .1)
        {
            GameObject.Destroy(gameObject);
        } else
        {
            timer += Time.deltaTime;
            transform.position = target;
        }
	}
}
