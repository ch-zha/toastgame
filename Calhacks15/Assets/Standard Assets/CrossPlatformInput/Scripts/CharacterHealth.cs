using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterHealth : MonoBehaviour
{

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;

    public Image blackScreen;
    public Text gameover;
    public Text score;

    public BackgroundPan panner;
    public GameObject leftbound;

    private float restart_timer = 20;
    private int score_value = 0;

    private Animator animator;
    private Rigidbody2D player;

    private Color origHeart;

    public int startingHealth = 4;
    public int currentHealth;
    
    private float dmg_timer = 0;
    private bool is_immune = false;
    private bool isDead = false;
    private bool hasDied = false;

    // Use this for initialization
    void Start()
    {

        origHeart = heart4.color;
        currentHealth = startingHealth;
        animator = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<Rigidbody2D>();
        blackScreen.color = Color.clear;
        gameover.color = Color.clear;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDied) {
            if (Input.GetMouseButton(0) || Input.GetButtonDown("Fire1"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
            return;
        }

        string displayedscore = score_value.ToString();
        score.text = displayedscore;

        heartDisplay();
        damage_timer();

    }


    void FixedUpdate()
    {
        if (isDead == true) { gameOver(); }
        if (gameObject.transform.position.x < leftbound.transform.position.x) { isDead = true; }
    }

    void damage_timer()
    {
        if (dmg_timer < 1)
        {
            dmg_timer += Time.fixedDeltaTime;
            animator.SetBool("isImmune", true);
            is_immune = true;
        }
        else
        {
            animator.SetBool("isImmune", false);
            is_immune = false;
        }
    }

    void heartDisplay()
    {
        if (currentHealth == 4)
        {
            heart4.color = origHeart;
            heart3.color = origHeart;
            heart2.color = origHeart;
            heart1.color = origHeart;
        }
        else if (currentHealth == 3)
        {
            heart4.color = Color.clear;
            heart3.color = origHeart;
            heart2.color = origHeart;
            heart1.color = origHeart;
        }
        else if (currentHealth == 2)
        {
            heart4.color = Color.clear;
            heart3.color = Color.clear;
            heart2.color = origHeart;
            heart1.color = origHeart;
        }
        else if (currentHealth == 1)
        {
            heart4.color = Color.clear;
            heart3.color = Color.clear;
            heart2.color = Color.clear;
            heart1.color = origHeart;
        }
        else
        {
            heart4.color = Color.clear;
            heart3.color = Color.clear;
            heart2.color = Color.clear;
            heart1.color = Color.clear;
        }
    }

    public void damage()
    {
        if (!is_immune && currentHealth > 1)
        {
            currentHealth -= 1;
            dmg_timer = 0;
        }
        else if (!is_immune && currentHealth == 1)
        {
            currentHealth -= 1;
            isDead = true;
        } else
        {
            return;
        }
    }

    int getCurrentHealth()
    {
        return currentHealth;
    }

    public void increaseScore()
    {
        score_value++;
    }

    void gameOver()
    {

        blackScreen.color = Color.Lerp(Color.clear, Color.black, Time.time / 2);
        gameover.color = Color.Lerp(Color.clear, Color.gray, Time.time / 2);
        panner.stopBackgroundPan();
        
        hasDied = true;
    }
}