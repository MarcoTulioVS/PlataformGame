using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CompanionEnding : MonoBehaviour
{
    [SerializeField]
    private float speed;

    
    private bool isMoving;

    private Rigidbody2D rb;

    public GameObject fadeScreen;
    public Text textScreen;
    public Text textScreenEnd;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isMoving = true;
    }

    
    void Update()
    {
        if (!isMoving)
        {
            Stop();
        }
        else
        {
            Move();
        }
        
    }

    private void Move()
    {
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }

    private void Stop()
    {
        rb.velocity = Vector2.zero;
        StartCoroutine("FadeScreen");
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dragon")
        {
            isMoving = false;

        }
    }

    private IEnumerator FadeScreen()
    {
        yield return new WaitForSeconds(5);
        fadeScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        textScreen.enabled = true;
        yield return new WaitForSeconds(2);
        textScreenEnd.enabled = true;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);

    }
}
