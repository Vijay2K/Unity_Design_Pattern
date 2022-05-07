using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;

    private ObjectPool_Advanced a_ObjectPool;

    private void Start()
    {
        a_ObjectPool = FindObjectOfType<ObjectPool_Advanced>();
    }

    private void Update()
    {
        transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        a_ObjectPool.ReturnToPool(this.gameObject);
    }
}
