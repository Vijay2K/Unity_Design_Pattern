using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI xpText;
    [SerializeField] private Button increaseXpBtn;

    private void Start()
    {
        increaseXpBtn.onClick.AddListener(() => level.GainExperience(10));
    }

    private void OnEnable()
    {
        level.onExperienceGain += UpdateUI;
    }

    private void OnDisable()
    {
        level.onExperienceGain -= UpdateUI;
    }

    private void UpdateUI()
    {
        levelText.text = level.GetLevel().ToString();
        xpText.text = level.GetExperiencePoint().ToString();
    }
}
