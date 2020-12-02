using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
        if (collision.GetComponent<Player>()!=null)
        {
            collision.GetComponent<Player>().OnDeath();
        }
        if (collision.tag == "Moving Platform") {
            collision.transform.parent.GetComponent<MovingPlatform>().GoBack();
            Debug.Log("This part works");

        }
    }
}
