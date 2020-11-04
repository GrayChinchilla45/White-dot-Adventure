using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject parent;
    private MovingPlatform mp;
    void Start()
    {
        parent = transform.parent.gameObject;
        mp = parent.GetComponent<MovingPlatform>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            ContactPoint2D contact = collision.GetContact(0);
            if (contact.normal.x == 0.0f && contact.normal.y == -1.0f)
            {
                mp.isMoving = true;
            }
        }
    }
}
