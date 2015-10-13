using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float speed = 10f;

    private Vector2 moving;

    private Rigidbody2D player;
    private CharacterHealth characterHealth;
    private Animator animator;
    
	void Start () {
        player = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        characterHealth = GetComponent<CharacterHealth>();
	}

    void Awake()
    {
    }

	void Update () {
	 
	}

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (isDamaged())
        {
            characterHealth.damage();
        }

        move(x, y);
    }

    void move(float x, float y)
    {
        moving.Set(x, y);
        moving = moving.normalized * speed * Time.deltaTime;
        player.MovePosition(player.position + moving);
    }

    bool isDamaged()
    {
        return player.IsTouchingLayers(1 << 11);
    }


}