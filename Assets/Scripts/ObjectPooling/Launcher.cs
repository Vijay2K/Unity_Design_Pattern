using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public bool useDefaultObjectPooling = false;
    private BulletPool bulletPool;

    private void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(useDefaultObjectPooling)
            {
                BulletPoolManager.instance.GetBulletPool().Get();
            }

            bulletPool.GetBullet(transform.position);
        }
    }
}
