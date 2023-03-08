using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private Rigidbody rb;
    public int BoostTime = 2;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            rb.drag = 0;
            rb.angularDrag = 1.5f;
            yield return new WaitForSeconds(BoostTime);
            rb.drag = 0.3f;
            rb.angularDrag = 1.2f;
        }

    }
}
