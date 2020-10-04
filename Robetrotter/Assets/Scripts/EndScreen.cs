using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    public GameObject Pause;
    private GameManager gamemanager;

    public GameObject hoverSound;


    void Awake()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        if (gamemanager.GameEnded)
            return;

        Pause.SetActive(!Pause.activeSelf);

        if (Pause.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PlayHoverSound()
    {
        GameObject sound = Instantiate(hoverSound);
        Destroy(sound, 2f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
