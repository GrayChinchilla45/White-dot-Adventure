using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector2 maxDistance;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        float dX = transform.position.x;
        float dY = transform.position.y;
        if (target.position.x - dX > maxDistance.x)
        {
            dX = target.position.x - maxDistance.x;
        }
        else if (target.position.x - dX < -maxDistance.x)
        {
            dX = target.position.x + maxDistance.x;
        }
        //======================================================================
        if (target.position.y - dY > maxDistance.y)
        {
            dY = target.position.y - maxDistance.y;
        }
        else if (target.position.y - dY < -maxDistance.y)
        {
            dY = target.position.y + maxDistance.y;
        }
        Vector3 pos = new Vector3(dX, dY, transform.position.z);
        transform.position = pos;
    }
}
