using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wolf_Movement : MonoBehaviour
{
    //pārvietošanās
    public bool isgrounded;
    public bool isSitting;
    private float speed;
    private float walk_speed = 0.5f;
    private float run_speed = 1f;
    public float rotate_speed;
    public static int count;
    public Text countText;
    public static int countdeath;
    public Text endgame;

    //animal destroying
    public GameObject DestroyingObjectsSelected;
    public bool isDestroying;
    public float DestroyingTimer;
    public Vector3 DestroyingStartPosition;
   
    //Dying
   
    public bool isDying;
 

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

        count = 0;
        countdeath = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))

            if (isSitting)
            {
                isSitting = false;
                anime.SetBool("isSitting", false);
                caps_col.height = 1;
                caps_col.center = new Vector3(0, 0.5f, 0);
            }
            else
            {
                isSitting = true;
                anime.SetBool("isSitting", true);
                caps_col.height = 1;
                caps_col.center = new Vector3(0, 0.5f, 0);
            }
        var z = Input.GetAxis("Vertical") * speed;
        var y = Input.GetAxis("Horizontal") * rotate_speed;

        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

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
        //    }
        // else 
        if (Input.GetKey(KeyCode.LeftShift))
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

        else if (!isSitting)
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
        if (Input.GetMouseButtonDown(1))
        {
            RightClickObject();
        }

        if (isDestroying)
        {
            if (DestroyingTimer > 0)
            {
                DestroyingTimer -= Time.deltaTime;
            }
            else
            {
                print("Destroyed animal");
                isDestroying = false;
                Destroy(DestroyingObjectsSelected.gameObject);
                count = count + 1;
                SetCountText();

            }


        }
        if (Input.GetMouseButtonDown(0))
        {
            LeftClickObject();
        }

        if (isDying)
        {
           
                print("YOU DIED");
                isDying= false;
                Destroy(gameObject);
            countdeath = count + 1;
            //endgame.text = "YOU DIED!";
        }
     

        }
        void RightClickObject()
        {
            Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2000))
                if (hit.transform.tag == "animal") { 
            {
                if (!isDestroying)
                {
                    print("destroying");
                    DestroyingObjectsSelected = hit.transform.gameObject;
                    DestroyingTimer = 0.5f;
                    isDestroying = true;
                    
                    }
            }
        }
    }
    void LeftClickObject()
    {
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;

        if (Physics.Raycast(ray2, out hit2, 2000))
            if (hit2.transform.tag == "Death")
            {
                {
                    if (!isDying)
                    {
                        print("dying");
                        DestroyingTimer = 0.5f;
                        isDying = true;
                    }
                }
            }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (countdeath >= 12)
        {
            endgame.text = "YOU DIED!";
        }
    }



}
