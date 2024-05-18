using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartEntryExitTest : MonoBehaviour
{
    [SerializeField] private PartCollector partCollector;

    void Start()
    {
        partCollector.AddPartEvent += setParent;
    }

    private void setParent(GameObject gameObject)
    {
        gameObject.transform.parent = partCollector.transform.parent;
    }
}
