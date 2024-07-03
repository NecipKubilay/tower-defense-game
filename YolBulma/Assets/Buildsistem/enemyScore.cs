using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScore : MonoBehaviour
{
    [SerializeField] int _killScore;

    private scoreKodu _skorKodu;

    private void Awake()
    {
        _skorKodu = FindAnyObjectByType<scoreKodu>();
    }

    public void SkorDondur()
    {
        _skorKodu.AddScore(_killScore);
    }
}
