using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int idk = 1;
    // Start is called before the first frame update
    public bool enabledBeforeVisible;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Awake()
    {
        if (!enabledBeforeVisible && !GetComponent<Renderer>().isVisible)
        {
            enabled = false;
        }
    }
    public void OnBecameVisible()
    {
        enabled = true;
    }
}
