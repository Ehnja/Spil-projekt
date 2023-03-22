using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private Rigidbody rb;
    public int BoostTime = 2;
   
    // Henter bilens rigidbody
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Hvis bilen rammer en boost, defineret ved tag "PickUp", så ændres drag-værdi, som resultere i et boost
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            rb.drag = 0;
            rb.angularDrag = 1.8f;
            yield return new WaitForSeconds(BoostTime);
            rb.drag = 0.3f;
            rb.angularDrag = 1.2f;
            yield return new WaitForSeconds(2);
            other.gameObject.SetActive(true);
        }

    }
}
