using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyKodu : MonoBehaviour
{
    //float speed = 5f;

    public GameObject target; // Hedef nesne
    private NavMeshAgent agent; // NavMeshAgent bileþeni
    public float health;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // NavMeshAgent bileþenini al

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
            agent.SetDestination(target.transform.position); // Hedef noktayý ayarla
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bullet") // Oyuncu mermisi ile çarpýþma
        {
            if (BulletKodu.instance != null)
            {
                float damage = BulletKodu.instance.damage;
                health -= damage; // Düþmandan hasarý çýkar
                Debug.Log("CAN : " + health);
            }



            if (health <= 0) // Düþman öldüyse
            {
                Death(); // Yok edilme fonksiyonu çaðrýlýr
            }

        }
    }



    void Death()
    {
        Destroy(this.gameObject);
    }
}
