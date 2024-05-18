using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public event Action EndEvent;

    [SerializeField] private List<Rigidbody> players = new();
    [SerializeField] private List<Transform> startPoints = new();

    public void Run()
    {
        for (int i = 0; i < players.Count ; i++)
        {
            players[i].transform.position = startPoints[i].position;
        }

        FindObjectOfType<PlayerHitChecker>().HitPlayerEvent += onPlayerHit;
        StartCoroutine(run());
    }

    private IEnumerator run()
    {
        float rate = 0;
        do
        {
            rate += Time.deltaTime * 10;
            var vector = players[0].transform.position - players[1].transform.position;
            vector.Normalize();
            vector *= rate;
            players[1].AddForce(vector);
            players[0].AddForce(-vector);
            yield return null;
        } while (true);
    }

    private void onPlayerHit()
    {
        //Debug.Log("onPlayerHit");
        StopAllCoroutines();
        var collectors = GameObject.FindObjectsOfType<PartCollector>();
        foreach(var pc in collectors)
        {
            foreach(var go in pc.GetParts())
            {
                go.transform.parent = null;
                go.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        StartCoroutine(endFlow());
    }

    private IEnumerator endFlow()
    {
        do
        {
            yield return null;
        }while (players[0].velocity.magnitude > .1f);
        //Debug.Log("End");
        EndEvent?.Invoke();
    }
}
