using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.LogWarning("ªÅ");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
