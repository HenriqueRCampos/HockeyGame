using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
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
    public GameObject countAnimator;
    public GameObject gametransition;
    public GameObject goalup;
    public GameObject goaldown;
    public Text lScore;
    public Text RScore;
    public Text timerUI;
    public List<GameObject> ScoreUP;
    public List<GameObject> ScoreDown;
    public List<ParticleSystem> golparticles;
    public List<GameObject> FinalUI;
    public GameObject defeatMid;
    public GameObject draw;
    public List<GameObject> PauseUI;
    public GameObject pauseButton;
    public static float gameTimer = 0; // tornal alteravel pelo menu principal
    public static float AuxTimer;
    int _scoreCounter;
    int _scoreCounter_two;
    int _one = 1;
    int _one_two = 1;
    bool gameover = false;
    public static bool gamePause;
    private bool countDownReady;
    void Start()
    {
        gameTimer = AuxTimer;

        if (AuxTimer == 0)
        {
            gameTimer = 90;
        }
        float minutes = Mathf.FloorToInt(gameTimer / 60);
        float seconds = Mathf.FloorToInt(gameTimer % 60);

        timerUI.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        playeroneScript.enabled = false;
        botScript.enabled = false;
        _scoreCounter = 0;
        _scoreCounter_two = 0;
        playertwoScript.gameObject.SetActive(false);
        botScript.gameObject.SetActive(true);
        golparticles[0].Stop();
        golparticles[1].Stop();
        golparticles[2].Stop();
        golparticles[3].Stop();
        StartCoroutine(Begin());
      
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
        if (!gameover && countDownReady)
        {
            gameTimer -= Time.deltaTime;
            if (gameTimer <= 0)
            {
                if (_scoreCounter > 0 || _scoreCounter_two > 0)
                {
                    playeroneScript.enabled = false;
                    playertwoScript.enabled = false;
                    botScript.enabled = false;
                    gamePause = true;
                    if (_scoreCounter == _scoreCounter_two)
                    {
                        FinalUI[0].SetActive(true);
                        FinalUI[7].SetActive(true);
                        draw.SetActive(true);
                       // Resultado.PortaFinal = 2;
                    }
                    else
                    {
                        StartCoroutine(EndGame());
                    }
                }
                else
                {
                    gamePause = true;
                    playeroneScript.enabled = false;
                    playertwoScript.enabled = false;
                    botScript.enabled = false;
                    FinalUI[0].SetActive(true);
                    FinalUI[7].SetActive(true);
                    defeatMid.SetActive(true);
                    //Resultado.PortaFinal = 1;
                }
                countDownReady = false;
                gameover = true;
                gameTimer = 0;
                timerUI.text = "00:00";
            }
            float minutes = Mathf.FloorToInt(gameTimer / 60);
            float seconds = Mathf.FloorToInt(gameTimer % 60);

            timerUI.text = string.Format("{0:00} : {1:00}", minutes, seconds);
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

    private IEnumerator Begin()
    {
        gametransition.SetActive(true);
        yield return new WaitForSeconds(5.2f);
        countAnimator.SetActive(true);
        yield return new WaitForSeconds(3.05f);
        countDownReady = true;
        Instantiate(_ballPrefab, new Vector2(-0.1599f, 0.3119f), Quaternion.identity);
        playeroneScript.enabled = true;
        botScript.enabled = true;
    }
    private IEnumerator EndGame()
    {
        gamePause = true;
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < FinalUI.Count; i++)
        {
            
            if(_scoreCounter > _scoreCounter_two && i == 1 || _scoreCounter > _scoreCounter_two && i == 4)
            {
                continue;
            }
            if (_scoreCounter_two > _scoreCounter && i == 2 || _scoreCounter_two > _scoreCounter && i == 3)
            {
                continue;
            }
            FinalUI[i].SetActive(true);
            switch (_scoreCounter)
            {
                case 0:
                 //   Resultado.PortaFinal = 1;
                    break;
                case 1:
                  //  Resultado.PortaFinal = 2;
                    break;
                case 2:
                 //   Resultado.PortaFinal = 2;
                    break;
                case 3:
                 //   Resultado.PortaFinal = 3;
                    break;

            }
        }
        yield return new WaitForSeconds(5.5f);
        PlayAgain();
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
        gamePause = false;
        gameover = false;
        SceneManager.LoadScene("CenaFinal");
    }
}