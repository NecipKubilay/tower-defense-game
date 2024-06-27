using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taretAim : MonoBehaviour
{

    public Transform target;

    [Header("Attributes")]

    public float range = 5f;
    public float fireRate = 0.2f;
    private float fireCountDown = 0f;


    [Header("Unity setup fields")]

    string enemyTag = "Enemy";
    public Transform rotasyon;
    float turnspeed = 20f;

    public GameObject bulletPrefab;
    public GameObject fireEffect;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.1f, 0.1f);
    }



    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distancetoEnemy < shortestDistance)
            {
                shortestDistance = distancetoEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;

        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotasyon.rotation, lookrotation, Time.deltaTime * turnspeed).eulerAngles;
        rotasyon.rotation = Quaternion.Euler(0, rotation.y, 0);



        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    void Shoot()
    {
        GameObject effect = (GameObject)Instantiate(fireEffect, firePoint.position, transform.rotation);
        
        Destroy(effect,1f);
        GameObject bulletgo = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        BulletKodu bullet = bulletgo.GetComponent<BulletKodu>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
        //Debug.Log("SHOOT");
    }

    








}
