using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextObject : MonoBehaviour
{
    
    public string targetTag = "Part";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag== targetTag)
        {
            Debug.Log("other");
            other.transform.SetParent(transform.parent);
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        
    }


}
