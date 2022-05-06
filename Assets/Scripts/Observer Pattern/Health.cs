using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float drainHealthPerSec = 2f;

    private float currentHealth = 0f;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(DrainHealth());
    }

    private void OnEnable()
    {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
        Debug.Log("Subscribed to onLevelUpAction event");
    }

    private void OnDisable()
    {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
        Debug.Log("Unsubscribed the onLevelUpAction event");
    }

    public float GetHealth() => currentHealth;

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    private IEnumerator DrainHealth()
    {
        while(currentHealth > 0)
        {
            currentHealth -= drainHealthPerSec;
            yield return new WaitForSeconds(1f);
        }
    }
}
