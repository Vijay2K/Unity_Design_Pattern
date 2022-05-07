using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float drainHealthPerSec = 2f;

    public event Action onHealthChange; 

    private float currentHealth = 0f;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(DrainHealth());
    }

    private void OnEnable()
    {
        FindObjectOfType<Level>().onLevelUpAction += ResetHealth;
        Debug.Log("Subscribed to onLevelUpAction event");
    }

    private void OnDisable()
    {
        FindObjectOfType<Level>().onLevelUpAction -= ResetHealth;
        Debug.Log("Unsubscribed the onLevelUpAction event");
    }

    public float GetHealth() => currentHealth;
    public float GetMaxHealth => maxHealth;


    public void ResetHealth()
    {
        currentHealth = maxHealth;
        HealthEvent();
    }

    private IEnumerator DrainHealth()
    {
        while(currentHealth > 0)
        {
            currentHealth -= drainHealthPerSec;

            HealthEvent();

            yield return new WaitForSeconds(1f);
        }
    }

    private void HealthEvent()
    {
        if (onHealthChange != null)
        {
            onHealthChange.Invoke();
        }
    }
}
