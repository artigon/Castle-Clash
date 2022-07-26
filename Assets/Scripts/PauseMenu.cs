using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
   public GameObject PausePanel;
   public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            PausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);

        }
    }
}
