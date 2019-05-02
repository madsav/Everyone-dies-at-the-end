using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Wolf_Movement movement;



    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "animal")
        {
            movement.enabled = false;
        }
      else  if (collisionInfo.collider.tag == "Death")
        {
            FindObjectOfType<Death>().WolfDeath();

        }

    }
}
