using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private int pointsPerLevel = 200;
    [SerializeField] private UnityEvent onLevelUp;

    public event Action onLevelUpAction;

    private int experiencePoint = 0;

    private IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    private void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoint += points;

        if(GetLevel() > level)
        {
            onLevelUp.Invoke();

            if(onLevelUpAction != null)
            {
                onLevelUpAction();
            }
        }
    }

    public int GetExperiencePoint() => experiencePoint;
    public int GetLevel() => experiencePoint / pointsPerLevel;
}
