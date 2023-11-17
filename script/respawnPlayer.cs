using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class respawnPlayer : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector;
    public TextMeshProUGUI scoreText;
    public GameObject Panel;
    public GameObject Finish;


    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        scoreText.text = "Poin : " + scoring.totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            Destroy(gameObject);
            transform.position = respawnPoint;
            Panel.SetActive(true);
        }
        else if (collision.tag == "checkpoint")
        {
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Nextlevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Prevlevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
        else if (collision.tag == "Poin")
        {
            scoring.totalScore += 1;
            scoreText.text = "Poin : " + scoring.totalScore;
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "finish")
        {
            Finish.SetActive(true);
        }
    }
}