using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kuleKodu : MonoBehaviour
{

    [SerializeField]
    public float kuleHP = 5f;

    [SerializeField] private Image canvasImage; // Canvas'a baðlý Image nesnesi
    [SerializeField] private float fadeSpeed = 1f; // Solma hýzý
    [SerializeField] private float beklemeSuresi= 5f;
    [SerializeField] private Color fadeColor = Color.white; // Solma rengi (beyaz)
    [SerializeField] private Color siyah = Color.black; // Solma rengi (siyah)


    public GameObject kanvas;
    public GameObject oyun;
    public Text oyunBitti;


    private float targetAlpha = 1f;
    bool bittimi;

    bool bitis;
    private void Start()
    {
        kanvas.SetActive(true);
        //oyun.SetActive(true);
        canvasImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0f);
        oyunBitti.color = new Color(siyah.r, siyah.g, siyah.b, 0f);
        bittimi = false;
        bitis = false;
    }
    
    private void Update()
    {
        if (bittimi)
        {
            canvasImage.color = Color.Lerp(canvasImage.color, new Color(fadeColor.r, fadeColor.g, fadeColor.b, targetAlpha), fadeSpeed * Time.deltaTime);
            oyunBitti.color = Color.Lerp(oyunBitti.color, new Color(siyah.r, siyah.g, siyah.b, targetAlpha), fadeSpeed * Time.deltaTime);
        }
        if (bitis)
        {
            oyunBitti.color = Color.Lerp(oyunBitti.color, new Color(siyah.r, siyah.g, siyah.b, 0f), fadeSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            kuleHP--;
            
            if (kuleHP <= 0)
            {
                StartCoroutine(kuleDestroy());
                bittimi = true;
            }
        }
    }

    IEnumerator kuleDestroy()
    {
        kanvas.SetActive(false);
        //oyun.SetActive(false);
        yield return new WaitForSeconds(beklemeSuresi);
        bitis = true;
        fadeSpeed = 2f;
        yield return new WaitForSeconds(10f);
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
        
    }
    

    
}
