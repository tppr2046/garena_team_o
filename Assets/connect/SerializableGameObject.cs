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
