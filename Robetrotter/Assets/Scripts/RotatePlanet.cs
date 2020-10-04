using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float startSpeed;
    public float maxSpeed;
    public float SpeedIncrease;

    public float speed;
    private GameManager gamemanager;

    void Awake()
    {
        speed = startSpeed;
        gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!gamemanager.Gamestarted)
            return;

        if(speed < maxSpeed)
        {
            speed += SpeedIncrease;
        }

        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }


}
