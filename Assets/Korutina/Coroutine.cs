using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    [SerializeField] private GameObject Vase2;

    [SerializeField] private GameObject Column1;

    private static int score;

    private void Start()
    {
        
        StartCoroutine(HideObject());
        Update();
      
    }

   void Update()
    {
        score = Wolf_Movement.count;


        if (score == 6)
        {
            Column1.SetActive(false);
        }
    }

    IEnumerator HideObject()
    {
        yield return new WaitForSeconds(5);
        Vase2.SetActive(false);

       
       
    }

}
