using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemy : Enemy
{
    public float jumpDelay=1;
    private float lastJumped;
    public float jumpVelocity = 12f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(9,10,true);   
    }

    // Update is called once per frame
    void Update()
    {
      if (Time.time-lastJumped>jumpDelay)
        {
            Jump();
          
        }
    }
    bool isOnGround()
    {
        ContactFilter2D cf = new ContactFilter2D();
        cf.useTriggers = false;
        LayerMask thingy = LayerMask.GetMask("Default");
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -Vector2.up, 1.5f,thingy);
        foreach (RaycastHit2D hit in hits)
        {


            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                Debug.DrawLine(transform.position, hit.point);
                
                return true;
            }
        }
        return false;
    }
    void Jump()
    {
        if (isOnGround())
        {
            rb.velocity += Vector2.up*jumpVelocity;
            lastJumped = Time.time;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DeathZone>() != null)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().OnDeath();
        }
    }

}
