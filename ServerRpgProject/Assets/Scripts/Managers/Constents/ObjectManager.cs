using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    List<GameObject> objects = new List<GameObject>();

    public void Add(GameObject go)
    {
        objects.Add(go);
    }

    public void Remove(GameObject go)
    {
        objects.Remove(go);
    }

    public void Clear()
    {
        objects.Clear();
    }
}
