using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu_Manager : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))//Level adýnda bir kayýt var mý ona bakýyoruz
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));//kayýtlý level indexini aldýk sahne yüklemeye koyduk
        }
        else
        {
            PlayerPrefs.SetInt("Level", 1);
            SceneManager.LoadScene(1);
        }
    }
}
