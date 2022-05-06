using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Without inheriting from the monobehaviour
public class AmbientAudioPlayer
{
    private static AmbientAudioPlayer instance = null;

    public static AmbientAudioPlayer GetInstance()
    {
        if(instance == null)
        {
            instance = new AmbientAudioPlayer();
        }

        return instance;
    }
}
