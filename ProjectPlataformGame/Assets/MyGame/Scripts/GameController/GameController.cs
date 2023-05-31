using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public PlayerAnimation playerAnimation;

    public GameObject gameOverScreen;

    public GameSaveState gameSaveState;

    public GameObject menuScreenPause;
    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GameOver()
    {
        playerAnimation.SetAnimation(3);
        yield return new WaitForSeconds(1.5f);
        playerAnimation.GetComponent<Transform>().position -= Vector3.down * 2 * Time.deltaTime;
        playerAnimation.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        gameOverScreen.SetActive(true);
        
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameSaveState.IndexLevel += 1;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameSaveState.IndexLevel);
    }

    public void DisableMenuScreenPause()
    {
        menuScreenPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void EnableMenuScreenPause()
    {
        menuScreenPause.SetActive(true);
        Time.timeScale = 0;
    }
}
