using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private Bullet bulletprefab;
    private Queue<Bullet> pool;

    private void Awake()
    {
        pool = new Queue<Bullet>();
        bulletprefab = Resources.Load<Bullet>("Prefabs/Bullet/Bullet");
    }

    public Bullet GetBullet(Vector3 spawnPoint)
    {
        if (pool.Count > 0)
        {
            Bullet bulletInstance = pool.Dequeue();
            bulletInstance.gameObject.SetActive(true);
            bulletInstance.gameObject.transform.position = spawnPoint;
            return bulletInstance;
        }
        else
        {
            Bullet bullet = Instantiate(bulletprefab);
            bullet.transform.position = spawnPoint;
            return bullet;
        }
    }


    public void ReturnToPool(Bullet bullet)
    {
        pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}
