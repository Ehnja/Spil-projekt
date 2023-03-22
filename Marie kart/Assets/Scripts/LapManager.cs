using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps;
    public TextMeshProUGUI LapNText;
    public TextMeshProUGUI PosText;
    public GameObject FinishTextObject;

    // Styre displayed tekst
    private void Start()
    {
        LapNText.text = "Lap 1";
        FinishTextObject.SetActive(false);
    }

    // Hvis bilen rammer finish objektet, tjekker den om alle checkpoints er ramt, hvis ja, så går lapnumber op.
    // Hvis lapnumber = totallaps, så er ræset slut, og finish bliver displayed
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
                    StartCoroutine(Finish());
                }
            }
        }
    }

    // Efter finish ventes der 5 sekunder, hvor der så skiftes scene tilbage til hovedmenu
    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
