using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;

    private BulletPool bulletPool;
    private Launcher launcher;

    private void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();
        launcher = FindObjectOfType<Launcher>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        if (launcher.useDefaultObjectPooling)
        {
            BulletPoolManager.instance.ReturnToBulletPool(this);
        }
        else
        {
            bulletPool.ReturnToPool(this);
        }
    }
}
