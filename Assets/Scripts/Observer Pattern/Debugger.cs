using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    private IEnumerator Start()
    {
        Health health = GetComponent<Health>();
        Level level = GetComponent<Level>();

        while(true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log($"Level : {level.GetLevel()}, Experience : {level.GetExperiencePoint()}, Health : {health.GetHealth()}");
        }
    }
}
