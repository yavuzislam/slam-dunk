using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Sure;
    [SerializeField] private int BaslangicSuresi;
    [SerializeField] private GameManager _GameManager;
    IEnumerator Start()
    {
        Sure.text = BaslangicSuresi.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1f);//1saniye bekle
            BaslangicSuresi--;
            Sure.text = BaslangicSuresi.ToString();
            if (BaslangicSuresi == 0)
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }
    /*IEnumerator SayacBaslasin()
    {
        Sure.text=BaslangicSuresi.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1f);//1saniye bekle
            BaslangicSuresi--;
            Sure.text = BaslangicSuresi.ToString();
            if (BaslangicSuresi==0)
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }*///direk startla baþlamasa böyle yapabilirdik.
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        _GameManager.PotaBuyut(transform.position);
    }
}
