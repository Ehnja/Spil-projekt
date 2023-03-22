using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{

    // Skifter scene til gameScene, vha. index værdi.
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Afslutter spillet
    public void quit()
    {        
        Application.Quit();
    }

}
