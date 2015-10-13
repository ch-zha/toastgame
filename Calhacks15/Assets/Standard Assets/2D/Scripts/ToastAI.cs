using UnityEngine;

public class ToastAI : MonoBehaviour {

    private Rigidbody2D toast;
    private Animator animator;
    private PolygonCollider2D collide;

    public Character character;

    private float toast_direction = 1;
    private float speed = 100f;
    private float jump_pwr = 150f;
    private LayerMask layers = (1 << 10) | (1 << 14);

    private float pre_jump = 0;
    private float jump_delay = 0;
    private float death_delay = 0;
    private bool wasShot = false;
    private bool isDead = false;
    private CharacterHealth characterUI;

    void Start()
    {
        jump_delay = Random.value;
        toast = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        collide = gameObject.GetComponent<PolygonCollider2D>();
        characterUI = character.GetComponent<CharacterHealth>();
    }


    void Update()
    {
    }

    void FixedUpdate()
    {
        if (isDead) { toastDies(); } else
        {
            if (isHit())
            {
                animator.SetTrigger("isHit");
                characterUI.increaseScore();
                isDead = true;
                toastDies();
            }
            if (jump_delay > 1 && canMove())
            {
                move();
                jump_delay = 0;
            }
            else if (jump_delay < 1)
            {
                jump_delay += Time.fixedDeltaTime;
            }
            else
            {
                ;
            }
        }
    }

    void move()
    {
        animator.SetTrigger("Move");
        if (pre_jump > 0.1)
        {
            if (isAtBarrier())
            {
                toast_direction = -toast_direction;
            }
            toast.AddForce(Vector2.up * jump_pwr);
            toast.AddForce(Vector2.right * toast_direction * speed);
            pre_jump = 0;

        }
        else
        {
            pre_jump += Time.fixedDeltaTime;
        }
    }

    bool canMove()
    {
        bool value = toast.IsTouchingLayers(1 << 8);

        animator.SetBool("canMove", value);
        return value;
    }

    bool isAtBarrier()
    {
        return toast.IsTouchingLayers(1 << 9);
    }

    bool isHit()
    {
        return (toast.IsTouchingLayers(layers) || wasShot);
    }

    public void gotShot()
    {
        wasShot = true;
    }

    void toastDies()
    {
        if (death_delay > 0.8)
        {
            GameObject.Destroy(gameObject);
        } else
        {
            death_delay += Time.fixedDeltaTime;
        }

    }
}
