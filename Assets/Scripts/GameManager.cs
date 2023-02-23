using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int EnemiesAlive = 0;//this is updated from the health scripts
    public static bool PlayerIsDeath = false;

    public Text soldierUI;

    public GameObject panelWinLose,winMsg,loseMsg,playAgainButton,quitButton;
    public StartScreen startScreen;    
    public GameObject playerPrefab;
    public GameObject firstAidParent;

    GameObject player;
    bool winLoseScreenIsUp = false;
    Transform[] firstAids;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlayerContainer");
        firstAids = firstAidParent.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        soldierUI.text = EnemiesAlive.ToString();

        if(!winLoseScreenIsUp)
        {
            if (EnemiesAlive == 0) PlayerWins();

            if (PlayerIsDeath) PlayerLoses();
        }      


    }

    private void PlayerLoses()
    {
        winLoseScreenIsUp = true;
        Invoke("ActivateLoseWindow", 3f);
        
    }
    private void ActivateLoseWindow()
    {
        panelWinLose.SetActive(true);
        loseMsg.SetActive(true);
        Time.timeScale = 0f;
    }

    private void PlayerWins()
    {
        winLoseScreenIsUp = true;
        Invoke("ActivateWinWindow", 3f);       
        
    }
    private void ActivateWinWindow()
    {
        panelWinLose.SetActive(true);
        winMsg.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayAgain()
    {
        //Clean all enemies died
        GameObject[] bodies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject body in bodies)
        {
            Destroy(body);
        }

        //Restart Spawner and enemies count
        Spawner.Instance.EnemiesToRespawn = Spawner.Instance.EnemiesOnLevel;
        EnemiesAlive = Spawner.Instance.EnemiesOnLevel;
        
        
        //Destroy player and create a new one.
        Destroy(player);        
        GameObject newPlayer = Instantiate(playerPrefab);
        player = newPlayer;
        PlayerIsDeath = false;

        //turn off Win/lose screen and  turn on Start screen
        loseMsg.SetActive(false);
        winMsg.SetActive(false);
        panelWinLose.SetActive(false);
        winLoseScreenIsUp = false;

        //getback First Aid packs
        foreach(Transform firstAid in firstAids)
        {
            firstAid.gameObject.SetActive(true);
        }


        startScreen.PauseAndStart();
        
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
