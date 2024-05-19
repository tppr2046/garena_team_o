using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{

    public float rotationSpeed = 0.1f;
    public GameObject expoled;
    float[] x = { -0.47f, 0.56f };
    float[] y = { 11.6f, 11.13f };
    float z = -53.9f;
    float _timer;
    bool isPlay;
    //List<GameObject> pool = new List<GameObject>();

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlay)
        {
            _timer += Time.deltaTime;
        }
        this.transform.Rotate(0, rotationSpeed, 0);
        if (_timer > 3)
        {
            isPlay = false;
            StopCoroutine(DoTrigger(0));
        }
    }
    public void SetSpeed(float speed)
    {
        rotationSpeed = speed;
    }
    public void TriggerStart(float speed)
    {
        StartCoroutine(DoTrigger(speed));
        isPlay = true;
    }
    IEnumerator DoTrigger(float speed)
    {
        //¼Q¯S®Ä
        Instantiate(expoled, this.transform.position,Quaternion.identity);
        //pool.Add(go);
        SetSpeed(speed);
        var timer = Random.Range(3, 20);
        for (int i = 0; i < timer; i++)
        {
        Instantiate(expoled, new Vector3(Random.Range(x[0],x[1]), Random.Range(y[0], y[1]),z) ,Quaternion.identity);

            var rate = Random.Range(0, 0.5f);
            yield return new WaitForSeconds(rate);
        }
    }
}
