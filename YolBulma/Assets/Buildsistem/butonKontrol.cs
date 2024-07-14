using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class butonKontrol : MonoBehaviour
{
    public Button satýnAlmaButonu;
    public UnityEvent TÝCK;

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
        //    satýnAlmaButonu.interactable = false;
        //}
        //if (paraKodu.Para > satinAlmaDegeri)
        //{
        //    satýnAlmaButonu.interactable = true;
        //}
    }

    public void butonSes()
    {
        
        //TÝCK.Invoke();
        tiklama.Play();
    }
}
