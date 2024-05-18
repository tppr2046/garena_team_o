using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settlement : MonoBehaviour
{
    [SerializeField] PartCollector p1;
    [SerializeField] PartCollector p2;
    [SerializeField] TextMeshProUGUI resultTxt;

    public void Run()
    {
        var count1 = p1.GetParts().Count;
        var count2 = p2.GetParts().Count;

        string result = string.Empty;

        if (count1 > count2)
        {
            result = "P1Àò³Ó!";
        }
        else if (count1 < count2)
        {
            result = "P2Àò³Ó!";
        }
        else
        {
            result = "P2Àò³Ó!";
        }
        resultTxt.text = result;
        gameObject.SetActive(true);
    }

}
