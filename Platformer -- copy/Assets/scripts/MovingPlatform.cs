using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum Direction {UpDown,LeftRight};
    public Direction direction;
    public float speed;
    public bool isMoving = false;
    private Rigidbody2D rb;
    private Vector3 startpos;
    private GameObject Player;
    private GameObject Physical;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        Player = GameObject.Find("Player");
        Player.GetComponent<Player>().death.AddListener(GoBack);
        Physical = transform.Find("Physical").gameObject;
        rb = Physical.GetComponent<Rigidbody2D>();
        if (direction == Direction.UpDown) {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
      if (isMoving)
        {
            if (direction == Direction.LeftRight)
            {
                rb.velocity = new Vector2(speed, 0.0f);
            }
            else
            {
                rb.velocity = new Vector2(0.0f, speed);
            }
       }
      else
        {
            rb.velocity = new Vector2();
        }
        transform.position = Physical.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    private void GoBack()
    {
        transform.position = startpos;
        isMoving = false;
    }

}