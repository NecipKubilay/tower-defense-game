using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyKodu : MonoBehaviour
{
    //float speed = 5f;

    public GameObject target; // Hedef nesne
    private NavMeshAgent agent; // NavMeshAgent bile�eni
    public float health;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bile�enini al

    }

    void Update()
    {
        Debug.Log("31");
        if (BulletKodu.instance != null)
        {
            Debug.Log(BulletKodu.instance.damage);
        }

        if (target != null) // Hedef nesne varsa
        {
            agent.SetDestination(target.transform.position); // Hedef noktay� ayarla
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bullet") // Oyuncu mermisi ile �arp��ma
        {
            if (BulletKodu.instance != null)
            {
                float damage = BulletKodu.instance.damage;
                health -= damage; // D��mandan hasar� ��kar
                Debug.Log("CAN : " + health);
            }



            if (health <= 0) // D��man �ld�yse
            {
                Death(); // Yok edilme fonksiyonu �a�r�l�r
            }

        }
    }



    void Death()
    {
        Destroy(this.gameObject);
    }
}
