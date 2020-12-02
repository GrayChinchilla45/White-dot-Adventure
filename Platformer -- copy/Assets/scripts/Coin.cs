using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private int NotDefinedYet;
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
      if (collision.GetComponent<Player>()!=null && !collision.GetComponent<Player>().freeze) {
            Player p = collision.GetComponent<Player>();
            p.Test(this);
         Destroy(gameObject);
        }  
    }

}