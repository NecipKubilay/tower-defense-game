using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class geriSayim : MonoBehaviour
{
    public Text timerText; // Geri sayým metni nesnesi
    private float currentTime; // Geri sayým süresi (saniye)
    [SerializeField] private float duration;

    public static geriSayim instance;
    private void Awake()
    {
        


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


    void Start()
    {
        currentTime = duration;
        timerText.text = currentTime.ToString();
        
    }

    void Update()
    {
        
    }




    public IEnumerator UpdateTime()
    {
        while (currentTime > 0)
        {
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        yield return null;
    }
}
