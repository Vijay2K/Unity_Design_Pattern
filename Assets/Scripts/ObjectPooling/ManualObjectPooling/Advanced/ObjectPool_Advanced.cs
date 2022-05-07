using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_Advanced : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> poolDict;

    private void Awake()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();
    }

    public GameObject SpawnObject(GameObject obj, Vector3 position)
    {
        if(poolDict.TryGetValue(obj.name, out Queue<GameObject> objectList))
        {
            if(objectList.Count > 0)
            {
                GameObject objectInstance = objectList.Dequeue();
                objectInstance.transform.position = position;
                objectInstance.SetActive(true);
                return objectInstance;
            }
            else
            {
                return CreateObject(obj, position);
            }
        }
        else
        {
            return CreateObject(obj, position);
        }
    }

    private GameObject CreateObject(GameObject obj, Vector3 position)
    {
        GameObject newObj = Instantiate(obj);
        newObj.name = obj.name;
        newObj.transform.position = position;
        return newObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        if(poolDict.TryGetValue(obj.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(obj);
        }
        else
        {
            Queue<GameObject> newList = new Queue<GameObject>();
            newList.Enqueue(obj);
            poolDict.Add(obj.name, newList);
        }

        obj.SetActive(false);
    }
}
