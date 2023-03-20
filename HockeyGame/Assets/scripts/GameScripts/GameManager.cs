using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Bot botScript;
    public PlayerTwo playertwoScript;
    public Player playeroneScript;
    public GameObject _ballPrefab;
    public GameObject goalup;
    public GameObject goaldown;
    public Text lScore;
    public Text RScore;
    public List<GameObject> ScoreUP;
    public List<GameObject> ScoreDown;
    public List<ParticleSystem> golparticles;
    public List<GameObject> FinalUI;
    public List<GameObject> PauseUI;
    public GameObject pauseButton;
    int _scoreCounter;
    int _scoreCounter_two;
    int _one = 1;
    int _one_two = 1;
    bool gameover = false;
    public static bool gamePause;
    void Start()
    {
        switch (MenuConfig.totalPlayers)
        {
            case 1: playertwoScript.gameObject.SetActive(false);
                botScript.gameObject.SetActive(true);
                    break;
            case 2:
                botScript.gameObject.SetActive(false);
                playertwoScript.gameObject.SetActive(true);
                break;
        }
        golparticles[0].Stop();
        golparticles[1].Stop();
        golparticles[2].Stop();
        golparticles[3].Stop();
        _scoreCounter = 0;
        _scoreCounter_two = 0;
        Instantiate(_ballPrefab, new Vector2(-0.1599f, 0.3119f), Quaternion.identity);
    }
    void Update()
    {
        if (Ball.goal && !gameover)
        {
            ScoreToPlayer(Ball._goalSide);
            StartCoroutine(UIgoalMessages());
            RScore.text = _scoreCounter.ToString();
            lScore.text = _scoreCounter_two.ToString();
            if (_scoreCounter == 3 || _scoreCounter_two == 3)
            {
                gameover = true;
                pauseButton.SetActive(false);
                playeroneScript.enabled = false;
                playertwoScript.enabled = false;
                botScript.enabled = false;
                StartCoroutine(EndGame());
            }
            Ball.goal = false;
        }
    }

    void ScoreToPlayer(GameObject _goalSide)
    {
        switch (_goalSide.name)
        {

            case "ResetBall":
                Instantiate(_ballPrefab, new Vector2(-0.1599f, 0.3119f), Quaternion.identity);
                break;
            case "GoalUp":
                Instantiate(_ballPrefab, new Vector2(-2f, 0.3119f), Quaternion.identity);
                goaldown.SetActive(true);
                golparticles[2].Play();
                golparticles[3].Play();
                Handheld.Vibrate();
                _scoreCounter = _one++;
                if (_scoreCounter > 3)
                {
                    _scoreCounter = 3;
                }
                for (int i = 0; i < ScoreDown.Count; i++)
                {
                    ScoreDown[_scoreCounter].SetActive(true);
                }
                break;
            case "GoalDown":
                Instantiate(_ballPrefab, new Vector2(2f, 0.3119f), Quaternion.identity);
                goalup.SetActive(true);
                golparticles[0].Play();
                golparticles[1].Play();
                Handheld.Vibrate();
                _scoreCounter_two = _one_two++;
                if(_scoreCounter_two > 3)
                {
                    _scoreCounter_two = 3;
                }
                for (int i = 0; i < ScoreUP.Count; i++)
                {
                    ScoreUP[_scoreCounter_two].SetActive(true);
                }
                break;
        }
    }

    private IEnumerator UIgoalMessages()
    {
        yield return new WaitForSeconds(2f);
        goalup.SetActive(false);
        goaldown.SetActive(false);
    }
    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < FinalUI.Count; i++)
        {
            
            if(_scoreCounter == 3 && i == 1 || _scoreCounter == 3 && i == 4)
            {
                continue;
            }
            if (_scoreCounter_two == 3 && i == 2 || _scoreCounter_two == 3 && i == 3)
            {
                continue;
            }
            FinalUI[i].SetActive(true);
        }
    }
    public void PauseGame()
    {
        gamePause = true;
        playeroneScript.enabled = false;
        playertwoScript.enabled = false;
        botScript.enabled = false;
        pauseButton.SetActive(false);
        for (int i = 0; i < PauseUI.Count; i++)
        {
            PauseUI[i].SetActive(true);
        }
    }
    public void ContinueGame()
    {
        gamePause = false;
        playeroneScript.enabled = true;
        playertwoScript.enabled = true;
        botScript.enabled = true;
        pauseButton.SetActive(true);
        for (int i = 0; i < PauseUI.Count; i++)
        {
            PauseUI[i].SetActive(false);
        }
    }
    public void CloseGame()
    {
        gamePause = false;
        SceneManager.LoadScene("Menu");
    }
    public void PlayAgain()
    {
        gameover = false;
        SceneManager.LoadScene("Menu");
    }
}