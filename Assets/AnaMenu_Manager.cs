using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu_Manager : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))//Level ad�nda bir kay�t var m� ona bak�yoruz
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));//kay�tl� level indexini ald�k sahne y�klemeye koyduk
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene(1);
        }
    }
}
