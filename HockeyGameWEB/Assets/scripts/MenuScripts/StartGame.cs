using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button readyButtonOne;
    public Button readyButtonTwo;
    public Button OnePlayerButton;
    public Button TwoPlayerButton;
    public Button backButton;
    public List<GameObject> difficults;

    private bool oneReady;
    private bool twoReady;

    private void Update()
    {
        if(oneReady && twoReady)
        {
            oneReady = false;
            twoReady = false;
            SceneManager.LoadScene("Game");
        }
    }
    private void UiGameObjects(bool turn)
    {
        for (int i = 0; i < difficults.Count; i++)
        {
            difficults[i].SetActive(turn);
        }
    }
    public void EasyMode()
    {
        MenuConfig.botForce = 10.3f;
        MenuConfig.botVelocity = 0.11f;
        UiGameObjects(false);
        SceneManager.LoadScene("Game");
    }
    public void MediumMode()
    {
        MenuConfig.botForce = 12.5f;
        MenuConfig.botVelocity = 0.16f;
        UiGameObjects(false);
        SceneManager.LoadScene("Game");
    }
    public void HardMode()
    {
        MenuConfig.botForce = 13.5f;
        MenuConfig.botVelocity = 0.2f;
        UiGameObjects(false);
        SceneManager.LoadScene("Game");
    }


    public void OnePlayer()
    {
        MenuConfig.playeRange = -3f;
        MenuConfig.totalPlayers = 1;
        OnePlayerButton.gameObject.SetActive(false);
        TwoPlayerButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        UiGameObjects(true);
    }
    public void TwoPlayers()
    {
        MenuConfig.playeRange = 0.05f;
        MenuConfig.totalPlayers = 2;
        OnePlayerButton.gameObject.SetActive(false);
        TwoPlayerButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
        readyButtonOne.gameObject.SetActive(true);
        readyButtonTwo.gameObject.SetActive(true);
    }
    public void Back()
    {
        UiGameObjects(false);
        backButton.gameObject.SetActive(false);
        readyButtonOne.gameObject.SetActive(false);
        readyButtonTwo.gameObject.SetActive(false);
        OnePlayerButton.gameObject.SetActive(true);
        TwoPlayerButton.gameObject.SetActive(true);
    }

    public void PlayerOneReady()
    {
        oneReady = !oneReady;
        if (oneReady)
        {
            readyButtonOne.image.color = new Color(0.184f, 0.858f, 0.291f);
        }
        else
        {
            readyButtonOne.image.color = new Color(0.867f, 0.11f, 0.110f);
        }
    }
    public void PlayerTwoReady()
    {
        twoReady = !twoReady;
        if (twoReady)
        {
            readyButtonTwo.image.color = new Color(0.184f, 0.858f, 0.291f);
        }
        else
        {
            readyButtonTwo.image.color = new Color(0.867f, 0.11f, 0.110f);
        }
    }
}
