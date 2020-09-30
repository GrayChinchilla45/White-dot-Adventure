using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    private bool isMoving = false;
    private Rigidbody2D rb;
    private Vector3 startpos;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startpos = transform.position;
        Player = GameObject.Find("Player");
        Player.GetComponent<Player>().death.AddListener(GoBack);
    }

    // Update is called once per frame
    void Update()
    {
      if (isMoving)
        {
            rb.velocity = new Vector2(speed, 0.0f);
        }
      else
        {
            rb.velocity = new Vector2();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null){
            ContactPoint2D contact = collision.GetContact(0);
            if (contact.normal.x == 0.0f && contact.normal.y ==-1.0f) {
                isMoving = true;
            }
        }
    }
    private void GoBack()
    {
        transform.position = startpos;
        isMoving = false;
    }

}