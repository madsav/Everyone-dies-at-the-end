using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    [SerializeField] private GameObject Vase2;
    
   
    private void Start()
    {
        
        StartCoroutine(HideObject());
    
    }

    IEnumerator HideObject()
    {
    
        yield return new WaitForSeconds(5);
        Vase2.SetActive(false);

    }
}
