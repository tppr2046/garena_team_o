using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> players = new();
    [SerializeField] private List<Transform> startPoints = new();

    public void Run()
    {
        for (int i = 0; i < players.Count ; i++)
        {
            players[i].transform.position = startPoints[i].position;
        }

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
}
