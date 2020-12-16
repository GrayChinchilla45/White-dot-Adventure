using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smarty : Enemy
{
    // Start is called before the first frame update
    public float speed = 2;
    public int direction = 1;
    public Collider2D dieCollider;
    public Collider2D damagePlayerCollider;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.right * direction * speed * Time.deltaTime;
        if (isObstructed() || willFallOff())
        {
            direction = -direction;        
        }
    }

    bool isObstructed()
    {
        ContactFilter2D cf = new ContactFilter2D();
        cf.useTriggers = false;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.right * direction, 2, 31);
        foreach (RaycastHit2D hit in hits)
        {


            if (hit.collider != null && hit.collider.gameObject != gameObject && hit.collider.gameObject.name != "DamagePlayerCollider")
            {
                Debug.DrawLine(transform.position, hit.point);
                return true;
            }
        }
        return false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DeathZone>() != null)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (dieCollider.IsTouching(collision.collider))
            {
                Destroy(gameObject);
            }
            else if (damagePlayerCollider.IsTouching(collision.collider))
            {
                collision.gameObject.GetComponent<Player>().OnDeath();
            }
        }
    }

    

    bool willFallOff()
    {
        ContactFilter2D cf = new ContactFilter2D();
        cf.useTriggers = false;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position+Vector3.right*direction, -Vector2.up, 1.25f, 31);
        foreach (RaycastHit2D hit in hits)
        {


            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                Debug.DrawLine(transform.position, hit.point);
                return false;
            }
        }
        return true;
    }
}

