using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class butonKontrol : MonoBehaviour
{
    public Button sat�nAlmaButonu;
    public UnityEvent T�CK;

    [SerializeField] AudioSource tiklama;
    //paraKodu paraKodu;
    //public int satinAlmaDegeri;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (paraKodu.Para < satinAlmaDegeri)
        //{
        //    sat�nAlmaButonu.interactable = false;
        //}
        //if (paraKodu.Para > satinAlmaDegeri)
        //{
        //    sat�nAlmaButonu.interactable = true;
        //}
    }

    public void butonSes()
    {
        
        //T�CK.Invoke();
        tiklama.Play();
    }
}
