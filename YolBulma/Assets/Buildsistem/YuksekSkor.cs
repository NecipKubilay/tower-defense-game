using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class YuksekSkor : MonoBehaviour
{

    public Text Skor;



    int gelenDEGER;
    int skorInt;
    // Start is called before the first frame update
    void Start()
    {
        skorInt = int.Parse(Skor.text);
        gelenDEGER = PlayerPrefs.GetInt("SKOR", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }


        if (gelenDEGER > skorInt)
        {
            Debug.Log(gelenDEGER);
            Skor.text = gelenDEGER.ToString();
        }
    }
}
