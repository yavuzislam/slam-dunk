using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Guc : MonoBehaviour
{
    [SerializeField] private float Aci;
    [SerializeField] private float UygulanacakGuc;
    private void OnCollisionEnter(Collision collision)//çarpýþmadaki iþlemler için
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Aci, 90, 0) * UygulanacakGuc, ForceMode.Force);
        //çarptýðý nesnenin(top) rigidbody özelliklerini al sonra ona güç uygula.
    }
}
