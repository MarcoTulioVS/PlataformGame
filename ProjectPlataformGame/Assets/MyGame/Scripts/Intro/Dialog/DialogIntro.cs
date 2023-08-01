using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogIntro : MonoBehaviour
{
    [SerializeField]
    private List<string> dialogList = new List<string>();

    public Text dialogText;

    private int indexDialog;

    public GameObject dialogBox;

    private bool dialogOn;
    void Start()
    {
        dialogOn = true;
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
            }
        }

        dialogText.text = dialogList[indexDialog].ToString();
    }
}
