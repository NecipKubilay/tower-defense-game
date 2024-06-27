using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlacement : MonoBehaviour
{

    public Material malzeme;

    public bool koyabilirmi = true;

    Renderer rend;


    public static checkPlacement instance;
    // Start is called before the first frame update

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

    void Start()
    {
        //buildSistem = GameObject.Find("BuildingManager").GetComponent<buildSistem>();
        rend = GetComponent<Renderer>();
        malzeme.color = Color.green;
        koyabilirmi = true;
    }


    private void Update()
    {
        //Debug.Log(koyabilirmi);

        

    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            koyabilirmi = false;
            malzeme.color = Color.red;
            Debug.Log("çarptý");
            //Debug.Log(koyabilirmi);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            koyabilirmi = false;
            malzeme.color = Color.red;
            Debug.Log("çarptý 2");
            //Debug.Log(koyabilirmi);

        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            koyabilirmi = true;
            malzeme.color = Color.green;
            Debug.Log(koyabilirmi);

        }
    }
}