using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class scoreKodu : MonoBehaviour
{

    public UnityEvent OnScoreChanged;

    public int Score {  get; private set; }
    
    public GameObject[] kilitliButonlar;
    public void AddScore(int deger)
    {
        Score += deger;
        OnScoreChanged.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        kilitliButonlar[0].SetActive(false);
        kilitliButonlar[1].SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Score >= 300)
        {
            
            kilitliButonlar[0].SetActive(true); // Nesnenin kilidini aç
            
        }

        if (Score >= 1350)
        {
            
            kilitliButonlar[1].SetActive(true); // Nesnenin kilidini aç
        }
    }
}
