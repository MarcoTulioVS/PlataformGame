using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public PlayerAnimation playerAnimation;

    public GameObject gameOverScreen;

    public GameSaveState gameSaveState;

    public GameObject menuScreenPause;

    public GameObject validateStartGameScreen;

    //Credits

    public Text audioText1;
    public Text audioText2;
    public GameObject previousButton;
    public GameObject nextButton;
    public GameObject creditPanelArt;
    public GameObject creditPanelAudio;


    public Transform checkpoint;
    public bool checkpointActive;
    public Text checkpointText;

    public Text lifeFullText;

    public Text gameTimeText;

    [SerializeField]
    private CompanionBite companionBite;

    [SerializeField]
    private List<GameObject> carrotsLife = new List<GameObject>();

    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
        //PlayerPrefs.DeleteKey("scene");
        gameSaveState.IndexLevel = PlayerPrefs.GetInt("scene");

        InstantiateObjects();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimeText.text = companionBite.time.ToString();
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
        
        gameSaveState.SaveGame();
        gameSaveState.IndexLevel += 1;
        gameSaveState.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        if (PlayerPrefs.HasKey("scene"))
        {
            validateStartGameScreen.SetActive(true);

        }
        else
        {
            gameSaveState.SaveGame();
            gameSaveState.IndexLevel += 1;
            gameSaveState.SaveGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ConfirmStartGame()
    {
        PlayerPrefs.DeleteKey("scene");
        gameSaveState.IndexLevel *= 0;

        gameSaveState.SaveGame();
        gameSaveState.IndexLevel += 1;
        gameSaveState.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void HideValidateStartGameScreen()
    {
        validateStartGameScreen.SetActive(false);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("scene"));
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

    public void EnableAudioText2()
    {
        audioText1.enabled = false;
        audioText2.enabled = true;
        previousButton.SetActive(true);
        nextButton.SetActive(false);
    }

    public void EnableCreditPanelArt()
    {
        creditPanelAudio.SetActive(false);
        creditPanelArt.SetActive(true);
    }

    public void EnableCreditPanelAudio()
    {
        creditPanelAudio.SetActive(true);
    }
    public void EnableAudioText1()
    {
        audioText1.enabled = true;
        audioText2.enabled =false;
        previousButton.SetActive(false);
        nextButton.SetActive(true);
    }

    public void DisableCreditPanel(GameObject creditPanel)
    {
        creditPanel.SetActive(false);
    }

    public void CheckPoint(Transform target)
    {
        target.position = checkpoint.localPosition;
    }

    public IEnumerator ShowMessage(Text message)
    {
        message.enabled = true;
        yield return new WaitForSeconds(3);
        message.enabled = false;
        StopCoroutine("ShowMessage");
    }

    public void ActivateAllCarrotsLife()
    {
        foreach(GameObject carrot in carrotsLife)
        {
            carrot.SetActive(true);
        }
    }

    private void InstantiateObjects()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            companionBite = new CompanionBite();
        }
    }

   
}
