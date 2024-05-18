using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPos : MonoBehaviour
{
    [SerializeField]
    Transform car;
    void Update()
    {
        gameObject.transform.position = car.position;
        gameObject.transform.rotation = car.rotation;
    }
}
