using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    private GameManager gamemanager;

    public GameObject DeathAudio;

    void Awake()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player" && !gamemanager.GameEnded)
        {
            gamemanager.GameEnd();
            GameObject sound = Instantiate(DeathAudio);
            Destroy(sound, 2f);
        }
    }

}
