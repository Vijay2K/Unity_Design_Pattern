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
    public event Action onExperienceGain;

    private int experiencePoint = 0;

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoint += points;
        
        if(onExperienceGain != null)
        {
            onExperienceGain.Invoke();
        }

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
