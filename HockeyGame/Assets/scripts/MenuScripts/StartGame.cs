using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject transition;
    public List<GameObject> difficults;

    private void Start()
    {
#if UNITY_WEBGL
        Resultado.RecaregarCena = SceneManager.GetActiveScene().name;
#endif
    }

    private void UiGameObjects()
    {
        foreach (GameObject UI in difficults)
        {
            UI.SetActive(false);
        }
    }
    public void loadGameScene()
    {
        StartCoroutine(startGame());
    }
    private IEnumerator startGame()
    {
        UiGameObjects();
        transition.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene("Game");
    }
    /*
    public void EasyMode()
    {
        MenuConfig.botForce = 10.3f;
        MenuConfig.botVelocity = 0.11f;
        UiGameObjects();
        SceneManager.LoadScene("Game");
    }
    public void MediumMode()
    {
        MenuConfig.botForce = 12.5f;
        MenuConfig.botVelocity = 0.16f;
        UiGameObjects();
        SceneManager.LoadScene("Game");
    }
    public void HardMode()
    {
        MenuConfig.botForce = 13.5f;
        MenuConfig.botVelocity = 0.2f;
        UiGameObjects();
        SceneManager.LoadScene("Game");
    }*/
}
