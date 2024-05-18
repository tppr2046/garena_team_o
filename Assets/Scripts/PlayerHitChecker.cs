using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitChecker : MonoBehaviour
{
    public event Action HitPlayerEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(Tags.Player))
        {
            HitPlayerEvent?.Invoke();
        }
    }
}
