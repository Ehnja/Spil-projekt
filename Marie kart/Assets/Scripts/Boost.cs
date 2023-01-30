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
            rb.angularDrag = 1;
            yield return new WaitForSeconds(2f);
            rb.drag = 0.5f;
            rb.angularDrag = 0.5f;
        }
    }
}
