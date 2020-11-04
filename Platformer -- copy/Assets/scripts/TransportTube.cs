using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransportTube : MonoBehaviour
{
    public GameObject placeToGo;
    public Player Player;
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
            Player = collision.gameObject.GetComponent<Player>();
            ContactPoint2D contact = collision.GetContact(0);
            if (contact.normal.x == 0.0f && contact.normal.y == -1.0f)
            {
                if (Input.GetKey("down") || Input.GetKey("s"))
                {
                    Debug.Log("Pipe Entered.");
                    Player.GetComponent<Player>().freeze = true;
                    Player.GetComponent<Player>().FadeOut(1.2f);
                    Invoke("SecondPart", 1.2f);
                }
            }
        }
    }
    void SecondPart()
    {
        Player.transform.position = new Vector3(placeToGo.transform.position.x, placeToGo.transform.position.y, Player.transform.position.z);
        Player.GetComponent<Player>().FadeIn(1.2f);
        Invoke("ThirdPart", 1.2f);

    }
    void ThirdPart()
    {
        Player.GetComponent<Player>().freeze = false;
    }
}