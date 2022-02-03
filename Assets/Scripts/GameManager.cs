using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameState currentGameState;

    public int currentScore;
    public Text ScoreText;

    public float startTime;
    public float timeRemaining;
    public float originalTimeRemaining;
    public Text countdownText;

    public List<GameObject> deactivatedUI;

    enum GameState
    {
        MENU,
        PLAYING,
        GAMEOVER
    }

    // Start is called before the first frame update
    void Start()
    {
        this.currentGameState = GameState.MENU;
        originalTimeRemaining = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentGameState) {
            case GameState.MENU:

                break;
            case GameState.PLAYING:

                FindObjectOfType<TapeSpawner>().shouldSpawn = true;
                ScoreText.text = currentScore.ToString();

                if (timeRemaining <= 0)
                {
                    // round over
                    this.currentGameState = GameState.GAMEOVER;
                }
                else
                {
                    timeRemaining -= Time.deltaTime;
                    countdownText.text = timeRemaining.ToString("0");
                }
                

                break;

            case GameState.GAMEOVER:
                EndGame();
                break;
        }
    }

    public void StartGame()
    {
        this.currentGameState = GameState.PLAYING;
        timeRemaining = originalTimeRemaining;
        currentScore = 0;

        deactivatedUI.Clear();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("startui");
        foreach (GameObject g in gameObjects)
        {
            deactivatedUI.Add(g);
            g.SetActive(false);
        }
    }

    void EndGame()
    {
        FindObjectOfType<TapeSpawner>().shouldSpawn = false;
        GameObject[] tapeObjects = GameObject.FindGameObjectsWithTag("tape");
        foreach (GameObject t in tapeObjects)
        {
            Destroy(t);
        }
        GameObject[] rewinderObjects = GameObject.FindGameObjectsWithTag("rewinder");
        foreach (GameObject r in rewinderObjects)
        {
            r.GetComponent<RewinderController>().ResetState();
        }
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("startui");
        foreach (GameObject g in deactivatedUI)
        {
            g.SetActive(true);
        }
    }
}
