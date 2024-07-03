using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGold : MonoBehaviour
{
    [SerializeField] int _killGold;

    private paraKodu _paraKodu;

    private void Awake()
    {
        _paraKodu = FindAnyObjectByType<paraKodu>();
    }

    public void ParaDondur()
    {
        _paraKodu.AddPara(_killGold);
    }
}
