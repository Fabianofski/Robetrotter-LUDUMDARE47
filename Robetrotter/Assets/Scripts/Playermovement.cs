using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

    public float JumpForce;
    public Transform GroundCheck;
    public LayerMask layers;
    public GameObject JumpParticle;
    public GameObject FallParticle;
    public GameObject JumpSound;
    public GameObject FallSound;
    private Rigidbody2D rb2d;
    private bool Grounded;
    private bool Jumped;

    private GameManager gamemanager;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gamemanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!gamemanager.Gamestarted)
            return;

        Grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.1f, layers); ;

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Grounded && !Jumped)
        {
            Jumped = true;
            Invoke("ResetJump", 0.05f);
            Jump();

            GameObject particle = Instantiate(JumpParticle, GroundCheck.position, Quaternion.identity);
            Destroy(particle, 2f);

            GameObject sound = Instantiate(JumpSound, GroundCheck.position, Quaternion.identity);
            Destroy(sound, 2f);
        }
    }

    void ResetJump()
    {
        Jumped = false;
    }

    void Jump()
    {
        rb2d.AddForce(Vector2.up * JumpForce);
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Earth" && gamemanager.Gamestarted)
        {
            GameObject particle = Instantiate(FallParticle, GroundCheck.position, Quaternion.identity);
            Destroy(particle, 2f);

            GameObject sound = Instantiate(FallSound, GroundCheck.position, Quaternion.identity);
            Destroy(sound, 2f);
        }
    }

}
