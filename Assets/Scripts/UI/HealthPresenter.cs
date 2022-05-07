using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image healthFillImg;

    private void OnEnable()
    {
        health.onHealthChange += UpdateUI;
    }

    private void OnDisable()
    {
        health.onHealthChange -= UpdateUI;
    }

    private void UpdateUI()
    {
        healthFillImg.fillAmount = health.GetHealth() / health.GetMaxHealth;
    }
}
