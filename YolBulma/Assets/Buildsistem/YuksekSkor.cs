using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class YuksekSkor : MonoBehaviour
{

    public Text Skor;


    
    int gelenDEGER;
    int HighskorInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        HighskorInt = int.Parse(Skor.text);

        gelenDEGER = PlayerPrefs.GetInt("SKOR");
        
        HighskorInt = PlayerPrefs.GetInt("highScore");

        Skor.text = HighskorInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }


        if (gelenDEGER < HighskorInt)
        {

            PlayerPrefs.SetInt("highScore", HighskorInt);
            Skor.text = HighskorInt.ToString();
        }
        if (gelenDEGER > HighskorInt)
        {
            HighskorInt = gelenDEGER;
            PlayerPrefs.SetInt("highScore", HighskorInt);
            Skor.text = HighskorInt.ToString();
        }
    }
}
