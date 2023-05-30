using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public PlayerAnimation playerAnimation;

    public GameObject gameOverScreen;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GameOver()
    {
        playerAnimation.SetAnimation(3);
        yield return new WaitForSeconds(3);
        playerAnimation.GetComponent<Transform>().position -= Vector3.down * 2 * Time.deltaTime;
        playerAnimation.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2);
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
    }
}
