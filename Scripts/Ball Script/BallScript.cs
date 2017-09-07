using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    private Rigidbody mybody;
    private bool rollLeft;

    public float speed=4f;

	// Use this for initialization
	void Awake () {
        mybody = GetComponent<Rigidbody>();
        rollLeft = true;

	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();
        CheckBallOut();

    }
    void FixedUpdate()
    {
        if (GameplayController.instance.gamepPlaying)
        {
            if (rollLeft)
            {
                mybody.velocity = new Vector3(-speed, Physics.gravity.y, 0f);
            }
            else
            {
                mybody.velocity = new Vector3(0f, Physics.gravity.y, speed);
            }
        }
    }

    void CheckBallOut()
    {
        if (GameplayController.instance.gamepPlaying)
        {
            if (transform.position.y < -4)
            {
                GameplayController.instance.gamepPlaying = false;
                Destroy(gameObject);
            }
        }
    }
    void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Test if we can play
            if (!GameplayController.instance.gamepPlaying)
            {
                GameplayController.instance.gamepPlaying = true;
                GameplayController.instance.AvtivateTileSpawner();
            }
        }
       if (GameplayController.instance.gamepPlaying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rollLeft = !rollLeft;
            }
        }
    }
}
