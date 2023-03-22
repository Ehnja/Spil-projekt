using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotere objekt hen af 3 akser.
        transform.Rotate(new Vector3(3, -30, 3) * Time.deltaTime * 3);
    }	
}
