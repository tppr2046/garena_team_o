using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{

    public float rotationSpeed = 0.1f;
    public GameObject expoled;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0, rotationSpeed, 0);
    }
    public void SetSpeed(float speed)
    {
        rotationSpeed = speed;
    }
    public void TriggerStart(float speed)
    {
        //¼Q¯S®Ä
        expoled.SetActive(true);
        SetSpeed(speed);
    }
}
