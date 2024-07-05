using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class enemyKodu : MonoBehaviour
{
    //float speed = 5f;


    public UnityEvent OnDied;

    public GameObject target; // Hedef nesne
    private NavMeshAgent agent; // NavMeshAgent bileþeni
    public GameObject deathEffect;
    [SerializeField] float health, maxhealth = 3f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bileþenini al
        health = maxhealth;
    }

    void Update()
    {

        Vector3 direction = (transform.position - target.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);



        if (target != null) // Hedef nesne varsa
        {
            agent.SetDestination(target.transform.position); // Hedef noktayý ayarla
        }



    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "bullet") // Oyuncu mermisi ile çarpýþma
    //    {
    //        int gelenDamage = BulletKodu.instance.damage;

    //        if (BulletKodu.instance != null)
    //        {
    //            Debug.Log("vurdu");
    //            health -= gelenDamage; // Düþmandan hasarý çýkar
    //            Debug.Log("CAN : " + health);
    //        }



    //        if (health <= 0) // Düþman öldüyse
    //        {
    //            Death(); // Yok edilme fonksiyonu çaðrýlýr
    //        }

    //    }
    //}

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bullet") // Oyuncu mermisi ile çarpýþma
        {
            int gelenDamage = BulletKodu.instance.damage;

            if (BulletKodu.instance != null)
            {
                health -= gelenDamage; // Düþmandan hasarý çýkar
                //Debug.Log("CAN : " + health);
            }



            if (health <= 0) // Düþman öldüyse
            {
                Death(); // Yok edilme fonksiyonu çaðrýlýr
            }



        }

        if (other.gameObject.tag == "Tower")
        {
            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);

            Destroy(effect, 1f);
            Destroy(gameObject);
        }
    }



    void Death()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);

        Destroy(effect, 1f);
        Destroy(gameObject);

        OnDied.Invoke();
    }

    //public void takeDamage(float damage)
    //{
    //    health -= damage;

    //    if (health <= 0) // Düþman öldüyse
    //    {
    //        Death(); // Yok edilme fonksiyonu çaðrýlýr
    //    }
    //}
}
