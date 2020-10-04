using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject EndUI;
    private Playermovement playermovement;
    public bool GameEnded;
    public int Score;
    public TextMeshProUGUI ScoreText;
    public Animator ScoreAnim;
    public TextMeshProUGUI EndScoreText;
    public TextMeshProUGUI HighscoreText;

    public Transform scoreWordPos;
    public GameObject ScoreParticle;
    public GameObject ScoreSound;
    public bool Gamestarted;
    public float Time = 4;

    public GameObject Meteorite;

    void Awake()
    {
        ScoreAnim = ScoreText.gameObject.GetComponent<Animator>();
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Playermovement>();

        Invoke("StartGame", Time);
    }

    void StartGame()
    {
        Gamestarted = true;

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetTrigger("run");
    }

    public void GameEnd()
    {
        GameEnded = true;
        playermovement.enabled = false;
        EndUI.SetActive(true);
        ScoreText.gameObject.SetActive(false);

        if (Score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", Score);
            PlayerPrefs.Save();
        }

        EndScoreText.text = "your score: " + Score;
        HighscoreText.text = "highscore: " + PlayerPrefs.GetInt("Highscore");

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Score" && !GameEnded && Gamestarted)
        {
            Score++;
            ScoreAnim.SetTrigger("Score");
            ScoreText.text = "" + Score;

            GameObject particle = Instantiate(ScoreParticle, scoreWordPos.position, Quaternion.identity);
            Destroy(particle, 2f);

            GameObject sound = Instantiate(ScoreSound);
            Destroy(sound, 2f);

            if (Score > 10)
            {
                Meteorite.SetActive(true);
            }


        }
    }
}
