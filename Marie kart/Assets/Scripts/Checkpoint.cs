using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int index;
    // Tjekker om bilen rammer et checkpoint, og gemmer hvilket checkpoint man er nået til
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
