using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCoin : MonoBehaviour
{
    public float size;
    public float zoomSize = 20;
    public float zoomOutTime = 1.2f;
    public float zoomStayTime = 15;
    public float zoomShrinkTime = 1.2f;
    private float timeSinceStart;
    private bool zoomedOut;
    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        size = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomedOut)
        {
            if (timeSinceStart<zoomOutTime)
            {
                progress = timeSinceStart / zoomOutTime;
            }
            else if (timeSinceStart > zoomOutTime + zoomStayTime) {
                progress = 1 - (timeSinceStart - zoomOutTime - zoomStayTime) / zoomShrinkTime;
            }
            if (timeSinceStart >zoomOutTime + zoomStayTime + zoomShrinkTime + 0.01)
            {
                Destroy(gameObject);
                Debug.Log("Functional");
            }
            timeSinceStart += Time.deltaTime;
            Camera.main.orthographicSize = Mathf.Lerp(size, zoomSize, progress);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()!=null)
        {
            zoomedOut = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false; 

        }
    }
}
