using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            BulletPoolManager.instance.GetBulletPool().Get();
        }
    }
}
