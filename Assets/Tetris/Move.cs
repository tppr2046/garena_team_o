using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void Update()
    {
       
        movementt();
    }
    public float speed;    
    private void movementt()
    {   
        if (Input.GetKey("d"))
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime*speed);
        }  

        
        if (Input.GetKey("a"))
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if (Input.GetKey("w"))
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        
        if (Input.GetKey("s"))
        {
            this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

    }
    private void movement()
    {   
        if (Input.GetKey("d"))
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }  

        
        if (Input.GetKey("a"))
        {
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
        
        if (Input.GetKey("w"))
        {
            this.gameObject.transform.position += new Vector3(0, 0, speed);
        }
        
        if (Input.GetKey("s"))
        {
            this.gameObject.transform.position -= new Vector3(0, 0, speed);
        }

    }
}
