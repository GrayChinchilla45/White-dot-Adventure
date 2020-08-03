using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float rotateSpeed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angleChange = new Vector3(0,0,rotateSpeed*Time.deltaTime);
        transform.Rotate(angleChange);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()!=null)
        {
            collision.GetComponent<Player>().OnDeath();
        }
    }
}
