using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Guc : MonoBehaviour
{
    [SerializeField] private float Aci;
    [SerializeField] private float UygulanacakGuc;
    private void OnCollisionEnter(Collision collision)//�arp��madaki i�lemler i�in
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Aci, 90, 0) * UygulanacakGuc, ForceMode.Force);
        //�arpt��� nesnenin(top) rigidbody �zelliklerini al sonra ona g�� uygula.
    }
}
