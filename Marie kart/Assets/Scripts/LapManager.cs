using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WheelController player = collision.gameObject.GetComponent<WheelController>();
            if (player.checkpointIndex == checkpoints.Count)
            {
                player.checkpointIndex = 0;
                player.lapNumber++;
                Debug.Log($"You are now on lap {player.lapNumber} out of {totalLaps}");

                if (player.lapNumber > totalLaps)
                {
                    Debug.Log("You Won");
                }
            }
        }
    }
}
