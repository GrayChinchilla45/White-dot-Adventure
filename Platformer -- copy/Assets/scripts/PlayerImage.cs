using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImage : MonoBehaviour
{
    public Transform playerTransform;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newx = playerTransform.position.x - cameraTransform.position.x;
        float newy = playerTransform.position.y - cameraTransform.position.y;
        float newz = transform.position.z;
        transform.position = new Vector3(newx, newy, newz);
    }
}
