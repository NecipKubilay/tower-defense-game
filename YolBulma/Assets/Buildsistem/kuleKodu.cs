using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kuleKodu : MonoBehaviour
{

    //scoreKodu skorDeger;
    int gelenSkor;

    //------------------HP ÝSLEMLERÝ----------------------

    [SerializeField]
    public int kuleHP = 5;

    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //----------------------------------------


    [SerializeField] private Image canvasImage; // Canvas'a baðlý Image nesnesi
    [SerializeField] private float fadeSpeed = 1f; // Solma hýzý
    [SerializeField] private float beklemeSuresi = 5f;
    [SerializeField] private Color fadeColor = Color.white; // Solma rengi (beyaz)
    [SerializeField] private Color siyah = Color.black; // Solma rengi (siyah)


    public GameObject kanvas;
    public GameObject oyun;
    public Text oyunBitti;


    private float targetAlpha = 1f;
    bool bittimi;

    bool bitis;


    //------------------------------------------------
    public int highScore;
    public static kuleKodu instance;
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

    //------------------------------------------------

    private void Start()
    {
        kanvas.SetActive(true);
        //oyun.SetActive(true);
        canvasImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 0f);
        oyunBitti.color = new Color(siyah.r, siyah.g, siyah.b, 0f);
        bittimi = false;
        bitis = false;


        gelenSkor = PlayerPrefs.GetInt("SKOR", 0);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(gelenSkor);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }

        if (bittimi)
        {
            canvasImage.color = Color.Lerp(canvasImage.color, new Color(fadeColor.r, fadeColor.g, fadeColor.b, targetAlpha), fadeSpeed * Time.deltaTime);
            oyunBitti.color = Color.Lerp(oyunBitti.color, new Color(siyah.r, siyah.g, siyah.b, targetAlpha), fadeSpeed * Time.deltaTime);
        }
        if (bitis)
        {
            oyunBitti.color = Color.Lerp(oyunBitti.color, new Color(siyah.r, siyah.g, siyah.b, 0f), fadeSpeed * Time.deltaTime);
        }


        //--------------hp canvas metodu-------------------
        kuleHealth();
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



                PlayerPrefs.SetInt("SKOR", scoreKodu.instance.Score);


                
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



    void kuleHealth()
    {
        if (kuleHP > numOfHearts)
        {
            kuleHP = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < kuleHP)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
