using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRecorder : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform upperTowerSpawnPoint;
    public Transform lowerTowerSpawnPoint;

    public Transform upperTowerSpawnPoint2;
    public Transform lowerTowerSpawnPoint2;

    public float fireRate;
    private float upperFireCooldown;
    private float lowerFireCooldown;


    void Start()
    {
        fireRate = 0.3f;
        upperFireCooldown = 0f;
        lowerFireCooldown = 0f;
    }
    void Update()
    {

        upperFireCooldown -= Time.deltaTime;
        lowerFireCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A) && upperFireCooldown <= 0f)
        {
            FireBullet(upperTowerSpawnPoint);
            upperFireCooldown = fireRate; 
        }

        if (Input.GetKeyDown(KeyCode.D) && lowerFireCooldown <= 0f)
        {
            FireBullet(lowerTowerSpawnPoint);
            lowerFireCooldown = fireRate; 
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && upperFireCooldown <= 0f)
        {
            FireBullet(upperTowerSpawnPoint2);
            upperFireCooldown = fireRate; 
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && lowerFireCooldown <= 0f)
        {
            FireBullet(lowerTowerSpawnPoint2);
            lowerFireCooldown = fireRate; 
        }
    }
    void FireBullet(Transform spawnPoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("shooting bullets from" + spawnPoint.name );
    }
    
}