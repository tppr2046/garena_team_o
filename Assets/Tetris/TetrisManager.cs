using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisManager : MonoBehaviour
{
    [SerializeField]
    float Xmin;
    [SerializeField]
    float Xmax;
    [SerializeField]
    float Zmin;
    [SerializeField]
    float Zmax;
    [SerializeField]
    float Y;
    [SerializeField]
    float tertrisTime;
    public List<GameObject> tetrisList;
    [Header("Stopwatch")]
    public float timeLimit;
    float stopwatchTime;
    public Text stopwatchDisplay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TetrisInstantiate",0, tertrisTime);
    }
    void TetrisInstantiate()
    {
        float playeronePosX=Random.Range(Xmin, Xmax);
        float playeronePosZ=Random.Range(Zmin, Zmax);
        float playertwoPosX=-playeronePosX;
        Vector3 PlayerOnePos = new Vector3(playeronePosX, Y, playeronePosZ);
        Vector3 PlayerTwoPos = new Vector3(playertwoPosX, Y, playeronePosZ);
        if (tetrisList.Count > 0)
        {
            
            int randomIndex = Random.Range(0, tetrisList.Count);
            GameObject selectedPrefab = tetrisList[randomIndex];

            
            Instantiate(selectedPrefab, PlayerOnePos, Quaternion.identity);
            Instantiate(selectedPrefab, PlayerTwoPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("空");
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateStopwatch();
    }
    void UpdateStopwatch()
    {
        stopwatchTime += Time.deltaTime;
        UpdateStopwatchDisplay();
        if (stopwatchTime >= timeLimit)
        {
            CancelInvoke("TetrisInstantiate");
            Debug.Log("時間到");
        }
    }
    void UpdateStopwatchDisplay()
    {
        //int minutes = Mathf.FloorToInt(stopwatchTime / 60);
        //int seconds = Mathf.FloorToInt(stopwatchTime % 60);
        float seconds = timeLimit - stopwatchTime;
        stopwatchDisplay.text = string.Format("{0:00}", seconds);//"{0:00}:{1:00}", minutes,
    }
}
