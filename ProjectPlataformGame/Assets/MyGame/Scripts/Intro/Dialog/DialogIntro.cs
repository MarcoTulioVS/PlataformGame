using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogIntro : MonoBehaviour
{
    [SerializeField]
    private List<string> dialogList = new List<string>();

    public Text dialogText;

    private int indexDialog;

    public GameObject dialogBox;

    public bool dialogOn;

    public GameObject gameNameScreen;

    public static DialogIntro instance; 
    void Start()
    {
        instance = this;
    }

    
    void Update()
    {
        if (dialogOn)
        {
            ShowDialog();
        }
    }

    private void ShowDialog()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            indexDialog++;

            if(indexDialog == dialogList.Count)
            {
                indexDialog = 0;
                dialogBox.SetActive(false);
                dialogOn = false;
                StartCoroutine("StartGameName");
            }
        }

        dialogText.text = dialogList[indexDialog].ToString();
    }

    private IEnumerator StartGameName()
    {
        yield return new WaitForSeconds(3);
        gameNameScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        gameNameScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
