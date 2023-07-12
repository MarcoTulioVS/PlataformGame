using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialController : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;

    public static TutorialController instance;

    private int indexDialog;

    public PlayerMovement playerMovement;

    private bool tutorialActive;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        NextDialog();
        dialogText.text = playerMovement.tutorialObj.GetComponent<Tutorial>().dialogContentList[indexDialog];
    }

    public void ShowDialogBox()
    {
        tutorialActive = true;
        Time.timeScale = 0;
        dialogBox.SetActive(true);
        
    }

    private void NextDialog()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            if (tutorialActive)
            {
                indexDialog++;
            }

            if (indexDialog == playerMovement.tutorialObj.GetComponent<Tutorial>().dialogContentList.Count)
            {
                tutorialActive=false;
                Time.timeScale = 1;
                indexDialog = 0;
                dialogBox.SetActive(false);
                
            }
            
        }
       
    }

    

}
