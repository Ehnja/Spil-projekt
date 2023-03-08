using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;
    public TextMeshProUGUI LapNText;
    public TextMeshProUGUI PosText;
    public GameObject FinishTextObject;

    private void Start()
    {
        LapNText.text = "Lap 1";
        FinishTextObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WheelController player = collision.gameObject.GetComponent<WheelController>();
            if (player.checkpointIndex == checkpoints.Count)
            {
                player.checkpointIndex = 0;
                player.lapNumber++;
                if (player.lapNumber <= totalLaps)
                {                    
                    LapNText.text = "Lap " + player.lapNumber.ToString();                    
                }
                if (player.lapNumber > totalLaps)
                {
                    FinishTextObject.SetActive(true);
                }
            }
        }
    }
}
