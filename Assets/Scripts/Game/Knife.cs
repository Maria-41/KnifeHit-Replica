using System.Collections;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 100f;

    private Rigidbody2D rigidBody;
    private bool isThrown;
    private bool isFallen;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        isThrown = false;
        isFallen = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isThrown)
        {
            Hit();
        }
        if (isFallen)
        {
            if (rigidBody != null)
            {
                rigidBody.AddTorque(0.2f, ForceMode2D.Impulse);
                rigidBody.AddForce(Vector2.down, ForceMode2D.Impulse);
            }

        }
    }

    void Hit()
    {
        isThrown = true;
        rigidBody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "target")
        {
            GetComponentInChildren<ParticleSystem>().Play();
            GameController.Instance.score++;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.tag == "fixedKnife")
        {
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x * 2, -2);
            }

            gameObject.tag = "fallknife";
            isFallen = true;


            GameController.Instance.isEndGame = true;
        }
    }

}
