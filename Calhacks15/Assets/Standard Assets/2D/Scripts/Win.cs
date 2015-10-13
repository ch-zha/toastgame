using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Win : MonoBehaviour {

    public Transform goal;
    public BackgroundPan panner;
    public Text levelclear;
    public Image whitescreen;
    
    private bool hasWon = false;

	// Use this for initialization
	void Start () {
        whitescreen.color = Color.clear;
        levelclear.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {

        if (hasWon) {
            if (Input.GetMouseButton(0) || Input.GetButtonDown("Fire1"))
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
            return;
        }
	    if (transform.position.x >= goal.position.x)
        {
            panner.stopBackgroundPan();
            clearlevel();
        }
        
	}

    void clearlevel()
    {
        hasWon = true;
        whitescreen.color = Color.white;
        levelclear.color = Color.grey;
    }
}
