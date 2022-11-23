using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Top : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private AudioSource TopSesi;
    private void OnTriggerEnter(Collider other)
    {
        TopSesi.Play();
        if (other.CompareTag("Basket"))
        {
            _GameManager.Basket(transform.position);
        }
        else if(other.CompareTag("OyunBitti"))
        {
            _GameManager.Kaybettin();
        }
        //else if (other.CompareTag("PotaBuyut"))
        //{
        //    _GameManager.PotaBuyut();
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        TopSesi.Play();//çarptýðý nesnelerin is triggerlarý kapalý olsa bile etkileþime girdiði için ses aktif olacak her çarptýðýnda 
    }
}
