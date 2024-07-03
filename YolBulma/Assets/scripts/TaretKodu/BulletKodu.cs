using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKodu : MonoBehaviour
{
    //public GameObject player;
    //Rigidbody rb;
    //public float force;

    public Transform target;

    public float lifeTime = 2.0f;

    public float speed = 70f;
    public int damage = 3;

    



    public static BulletKodu instance;
    private void Awake()
    {
        DontDestroyOnLoad(this);


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;

    }


    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //player = GameObject.FindGameObjectWithTag("Player");

        //// Hedef ve kendi konumumuz arasýndaki vektörü hesapla
        //Vector3 direction = target.transform.position - transform.position;

        //// Yönü normalize et (büyüklüðü 1 yap)
        //direction.Normalize();

        //// Hýz vektörünü oluþtur
        //rb.velocity = direction * force;

        //// Y ekseninde açý hesaplama (Hedefe doðru bakma)
        //float rotY = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg;

        //// Dönüþü uygula (Sadece y ekseninde)
        //transform.rotation = Quaternion.Euler(0, rotY, 90);
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
            return;
        }



        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Destroy(gameObject,1f);
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


        //--------------------Merminin y ekseninde dusmana dogru rotasyon yapmasý ve kapsulun 90 derece egik olmasý---------------------

        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();
        float rotY = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, rotY, 90);

        //-----------------------------------------
    }

    void hitTarget()
    {

        Destroy(this.gameObject);

    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.TryGetComponent<enemyKodu>(out enemyKodu enemyComponent))
    //    {
    //        enemyComponent.takeDamage(damage);

    //        Destroy(gameObject);
    //    }
    //}

    //void Start()
    //{
    //    //rb = GetComponent<Rigidbody>();
    //    //player = GameObject.FindGameObjectWithTag("Player");

    //    //// Hedef ve kendi konumumuz arasýndaki vektörü hesapla
    //    //Vector3 direction = target.transform.position - transform.position;

    //    //// Yönü normalize et (büyüklüðü 1 yap)
    //    //direction.Normalize();

    //    //// Hýz vektörünü oluþtur
    //    //rb.velocity = direction * force;

    //    //// Y ekseninde açý hesaplama (Hedefe doðru bakma)
    //    //float rotY = Mathf.Atan2(direction.z, -direction.x) * Mathf.Rad2Deg;

    //    //// Dönüþü uygula (Sadece y ekseninde)
    //    //transform.rotation = Quaternion.Euler(0, rotY, 90);
    //}
}
