using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject projectile;
    public float delay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchProjectiles());  
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnProjectile()
    {
        Instantiate(projectile,spawnPoint.position,transform.rotation);
    }
    public IEnumerator LaunchProjectiles()
    {
        while (true) {
            yield return new WaitForSeconds(delay);
            SpawnProjectile();
        }
    }
}