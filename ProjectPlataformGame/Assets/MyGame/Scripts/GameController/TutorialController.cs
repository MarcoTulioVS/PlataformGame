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
        dialogBox.SetActive(true);
        
    }

    private void NextDialog()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            indexDialog++;
        }
       
    }

    

}
