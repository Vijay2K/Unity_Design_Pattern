using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedPoolLauncher : MonoBehaviour
{
    private ObjectPool_Advanced objectPool;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool_Advanced>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            objectPool.SpawnObject(Resources.Load<GameObject>("Prefabs/AD_Bullet/Bullet"), transform.position);
        }
        
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            objectPool.SpawnObject(Resources.Load<GameObject>("Prefabs/AD_Bullet/Cube_Bullet"), transform.position);
        }
    }
}
