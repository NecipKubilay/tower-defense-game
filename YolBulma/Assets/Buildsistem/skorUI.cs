using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class skorUI : MonoBehaviour
{
    private TMP_Text _skorText;


    private void Awake()
    {
        _skorText = GetComponent<TMP_Text>();
    }

    public void updateScore(scoreKodu skorkodu)
    {
        _skorText.text = $"{skorkodu.Score}";
    }
}
