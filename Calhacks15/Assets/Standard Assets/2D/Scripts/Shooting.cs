using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject bolt;
    public GameObject beam;
    private GameObject caster;

    private Vector3 shooter;
    private Vector2 beamshooter;

    private Animator animator;
    private LineRenderer beamline;
    private GameObject new_bolt;
    private GameObject new_beam;
    private RaycastHit2D[] hit;
    private RaycastHit2D[] hit2;
    private LayerMask toastmask = (1 << 11);
    

	// Use this for initialization
	void Start () {
        caster = gameObject;
        animator = caster.GetComponent<Animator>();
        beamline = gameObject.GetComponent<LineRenderer>();
        beamline.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
    }

    void FixedUpdate()
    {
        shooter = caster.transform.position;
        beamshooter = caster.transform.position + Vector3.right * 5;

        beamline.SetPosition(0, beamshooter + Vector2.up * (1/4));
        beamline.SetPosition(1, beamshooter + Vector2.up * (1/4) + Vector2.right * 10);

        if (Input.GetButtonDown("Fire2") || Input.GetMouseButtonDown(1))
        {
            shootBolt();
        }

        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            shootBeam();
        }
        
        
    }

    void shootBolt()
    {
        animator.SetTrigger("Shoot");
        new_bolt = (GameObject) Instantiate(bolt, shooter, new Quaternion(0, 0, 0, 0));
        Rigidbody2D bolt_body = new_bolt.GetComponent<Rigidbody2D> ();
        bolt_body.AddForce(Vector2.right * 500);
    }

    void shootBeam()
    {
        animator.SetTrigger("Shoot");
        new_beam = (GameObject) Instantiate(beam, beamshooter, new Quaternion(0, 0, 0, 0));
        new_beam.GetComponent<Beam>().target = beamshooter;
    }

    RaycastHit2D[] combinebeams (RaycastHit2D[] A, RaycastHit2D[] B)
    {
        RaycastHit2D[] result = new RaycastHit2D[A.Length + B.Length];
        A.CopyTo(result, 0);
        B.CopyTo(result, A.Length);
        return result;
    }
}
