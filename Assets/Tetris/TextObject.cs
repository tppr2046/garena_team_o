using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    
    public string targetTag = "TextObject";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== targetTag)
        {
            Debug.Log(other);
            transform.SetParent(other.transform);
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        
    }


}
