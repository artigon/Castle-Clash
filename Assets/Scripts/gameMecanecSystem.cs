using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameMecanecSystem : MonoBehaviour
{
    public int playesCoins, enemyCoins;
    public Text playrsCoinsText;
    public bool playerWins = false, enemyWins = false,
        stopCoinLoop = false;
    public GameObject endGamePanel, winScreen, loseScreen, backToLobyBtn;
    // Start is called before the first frame update
    void Start()
    {
        //playesCoins = 1000;//mabye change
        //enemyCoins = 100;
        startLoop();

    }

    // Update is called once per frame
    void Update()
    {

        playrsCoinsText.text = "" + playesCoins;
        if(playerWins)
        {
            StartCoroutine(endGame(true));

        }
        else if(enemyWins)
        {
            StartCoroutine(endGame(false));
        }
    }
    public void startLoop()
    {
        StartCoroutine(addCoin());
    }
    IEnumerator addCoin()
    {
        if (!stopCoinLoop)
        {
            playesCoins += 50;
            enemyCoins += 50;
            yield return new WaitForSeconds(5);
            StartCoroutine(addCoin());
        }
    }

    IEnumerator endGame(bool check)
    {
        yield return new WaitForSeconds(5);
        if(check)
        {
            stopCoinLoop = true;
            endGamePanel.SetActive(true);
            winScreen.SetActive(true);
            backToLobyBtn.SetActive(true);
        }
        else
        {
            stopCoinLoop = true;
            endGamePanel.SetActive(true);
            loseScreen.SetActive(true);
            backToLobyBtn.SetActive(true);
        }
    }
}
