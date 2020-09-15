using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBill : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 4.5f;
    public float lifeTime = 30;
    private bool canExplode = false;
    public float invincibleTime = 1.5f;
    
    void Start()
    {
        StartCoroutine(WaitOutLife());
        StartCoroutine(InvincibleTime());

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime; 
    }
    public IEnumerator WaitOutLife ()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Player>()!=null)
        {
            collision.collider.GetComponent<Player>().OnDeath();
            Destroy(gameObject);
        }
        LayerMask mask = LayerMask.GetMask("Default");
        if(collision.otherCollider.IsTouchingLayers(mask) && canExplode)
        {
           
            Destroy(gameObject);
        }
    }
    public IEnumerator InvincibleTime ()
    {
        yield return new WaitForSeconds(invincibleTime);
        canExplode = true;
    }
}
