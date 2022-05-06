using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresistentObjectSpawner : MonoBehaviour
{
    private GameObject PresistentObj;

    private static bool hasSpawned = false;

    private void Awake()
    {
        if (hasSpawned) return;

        SpawnPresistentObject();
        hasSpawned = true;

    }

    private void SpawnPresistentObject()
    {
        PresistentObj = Resources.Load<GameObject>("Prefabs/Presistent/PresistentObjects");
        GameObject presistentObjInstance = Instantiate(PresistentObj);
        DontDestroyOnLoad(presistentObjInstance);
    }

}
