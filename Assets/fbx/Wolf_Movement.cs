using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Movement : MonoBehaviour
{

    public bool isgrounded;
    private float speed;
    private float walk_speed = 0.05f;
    private float run_speed = 0.1f;

    public float rotate_speed;

    Rigidbody rbody;
    Animator anime;
    CapsuleCollider caps_col;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
        caps_col = GetComponent<CapsuleCollider>();
        isgrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //   var z = Input.GetAxis("Vertical") * speed;
     //   var y = Input.GetAxis("Horizontal") * rotate_speed;

        if (isgrounded)
        {
            if (Input.GetKey(KeyCode.W))
                
            {
                anime.SetBool("isWalking", true);
                anime.SetBool("isRunning", false);
                anime.SetBool("isIddle", false);
            }            

            else if (Input.GetKey(KeyCode.S))
            {
                anime.SetBool("isWalking", true);
                anime.SetBool("isRunning", false);
                anime.SetBool("isIddle", false);
            }
            else
            {
                anime.SetBool("isWalking", false);
                anime.SetBool("isRunning", false);
                anime.SetBool("isIddle", true);
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = run_speed;
            if (Input.GetKey(KeyCode.W))
            {
                anime.SetBool("isWalking", false);
                anime.SetBool("isRunning", true);
                anime.SetBool("isIddle", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anime.SetBool("isWalking", false);
                anime.SetBool("isRunning", true);
                anime.SetBool("isIddle", false);
            }
            else
            {
                anime.SetBool("isWalking", false);
                anime.SetBool("isRunning", false);
                anime.SetBool("isIddle", true);
            }
        }

        else if (Input.GetKey(KeyCode.W))
        {
            speed = walk_speed;
            if (Input.GetKey(KeyCode.W))
            {
                anime.SetBool("isWalking", true);
                anime.SetBool("isRunning", false);
                anime.SetBool("isIddle", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anime.SetBool("isWalking", true);
                anime.SetBool("isRunning", false);
                anime.SetBool("isIddle", false);
            }
            else
            {
                anime.SetBool("isWalking", false);
                anime.SetBool("isRunning", false);
                anime.SetBool("isIddle", true);
            }
        }
    }

}
