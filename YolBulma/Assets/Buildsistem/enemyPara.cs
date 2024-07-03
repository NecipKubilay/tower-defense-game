using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPara : MonoBehaviour
{
    [SerializeField] int _killGold;

    //public paraKodu _paraKodu;
    
    private void Awake()
    {
        //_paraKodu = FindAnyObjectByType<paraKodu>();
        
    }

    public void ParaDondur()
    {
        paraKodu.instance.AddPara(_killGold);
    }
}
