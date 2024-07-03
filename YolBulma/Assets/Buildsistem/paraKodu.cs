using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class paraKodu : MonoBehaviour
{
    public UnityEvent OnGoldChanged;
    private int[] money = { 80, 100, 120 };


    public int Para { get; private set; }



    public static paraKodu instance;
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



    public void AddPara(int para)
    {
        Para += para;
        OnGoldChanged.Invoke();
    }

    public void taretAl(int index)
    {
        Para -= money[index];
        OnGoldChanged.Invoke();
    }



    public Button[] sat�nAlmaButonu;
    
    public int[] satinAlmaDegeri;


    // Start is called before the first frame update
    void Start()
    {
        Para = 400;
    }

    // Update is called once per frame
    void Update()
    {
        if (Para < satinAlmaDegeri[0])
        {
            sat�nAlmaButonu[0].interactable = false;
        }
        if (Para < satinAlmaDegeri[1])
        {
            sat�nAlmaButonu[1].interactable = false;
        }
        if (Para < satinAlmaDegeri[2])
        {
            sat�nAlmaButonu[2].interactable = false;
        }

        //---------------------------------------------------

        if (Para > satinAlmaDegeri[0])
        {
            sat�nAlmaButonu[0].interactable = true;
        }
        if (Para > satinAlmaDegeri[1])
        {
            sat�nAlmaButonu[1].interactable = true;
        }
        if (Para > satinAlmaDegeri[2])
        {
            sat�nAlmaButonu[2].interactable = true;
        }
    }
}
