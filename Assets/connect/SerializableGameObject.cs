using System;
using UnityEngine;

[Serializable]
public class SerializableGameObject
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;

    public SerializableGameObject(GameObject gameObject)
    {
        name = gameObject.name;
        position = gameObject.transform.position;
        rotation = gameObject.transform.rotation;
    }

}

public class SerializableGameObjectArray
{
    public SerializableGameObject[] serializableGameObjects;

    public SerializableGameObjectArray(GameObject gameObject)
    {
        serializableGameObjects = new SerializableGameObject[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            serializableGameObjects[i] = new SerializableGameObject(gameObject.transform.GetChild(i).gameObject);
        }
    }
}