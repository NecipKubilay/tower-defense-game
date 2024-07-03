using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class paraUI : MonoBehaviour
{
    private TMP_Text _paraText;


    private void Awake()
    {
        _paraText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _paraText.text = "400";
    }

    public void updateScore(paraKodu parakodu)
    {
        _paraText.text = $"{parakodu.Para}";
    }
}
