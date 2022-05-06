using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolManager : MonoBehaviour
{
    private Bullet bulletPrefab;
    private ObjectPool<Bullet> bulletPool;

    public static BulletPoolManager instance;

    private void Awake()
    {
        instance = this;
        bulletPrefab = Resources.Load<Bullet>("Prefabs/Bullet/Bullet");
    }

    private void Start()
    {
        bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGet, OnRelease);        
    }

    public ObjectPool<Bullet> GetBulletPool()
    {
        return bulletPool;
    }

    public void ReturnToBulletPool(Bullet bullet)
    {
        bulletPool.Release(bullet);
    }

    private Bullet CreateBullet()
    {
        Bullet bulletInstance = Instantiate(bulletPrefab);
        return bulletInstance;
    }

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = this.transform.position;
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

}
