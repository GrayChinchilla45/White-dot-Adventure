using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportTube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            ContactPoint2D contact = collision.GetContact(0);
            if (contact.normal.x == 0.0f && contact.normal.y == -1.0f)
            {
                if (Input.GetKey("down") || Input.GetKey("s"))
                {
                    Debug.Log("Pipe Entered.");
                }
            }
        }
    }
}