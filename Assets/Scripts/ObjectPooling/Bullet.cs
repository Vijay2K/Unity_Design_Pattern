using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;

    private void Update()
    {
        transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        BulletPoolManager.instance.ReturnToBulletPool(this);
    }
}
