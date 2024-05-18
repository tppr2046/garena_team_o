using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settlement : MonoBehaviour
{
    [SerializeField] PartCollector p1;
    [SerializeField] PartCollector p2;

    public void Run()
    {
        var count1 = p1.GetParts().Count;
        var count2 = p2.GetParts().Count;

        if (count1 > count2)
        {
            Debug.Log("P1 win");
        }
        else if (count1 < count2)
        {
            Debug.Log("P2 win");
        }
        else
        {
            Debug.Log("Tie");
        }
    }

}
