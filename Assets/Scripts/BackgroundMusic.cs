using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    private static BackgroundMusic backgroundMusic;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            backgroundMusic = this;
            //DontDestroyOnLoad(backgroundMusic);
        }

        else if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            Destroy(gameObject);
        }
    }

}
