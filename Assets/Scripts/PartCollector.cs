using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCollector : MonoBehaviour
{
    public event Action<GameObject> AddPartEvent;

    private HashSet<GameObject> parts = new();

    public HashSet<GameObject> GetParts() => parts;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(Tags.Part))
        {
            parts.Add(other.gameObject);
            AddPartEvent?.Invoke(other.gameObject);
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(Tags.Part))
        {
            parts.Remove(other.gameObject);
        }
    }
}
