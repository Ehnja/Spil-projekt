using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WheelController player = collision.gameObject.GetComponent<WheelController>();
            if (player.checkpointIndex == index - 1)
            {
                player.checkpointIndex = index;
            }
        }
    }
}
