using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuScript : MonoBehaviour
{

    [SerializeField] private Image canvasImage;
    [SerializeField] private float fadeSpeed = 1f; // Solma h�z�
    [SerializeField] private Color fadeColor = Color.white; // Solma rengi (beyaz)
    private float targetAlpha = 0f;

    private void Start()
    {
        canvasImage.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f);
       
    }

    private void Update()
    {
        canvasImage.color = Color.Lerp(canvasImage.color, new Color(fadeColor.r, fadeColor.g, fadeColor.b, targetAlpha), fadeSpeed * Time.deltaTime);
    }
    public void PlayOnClick()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitOnClick()
    {
        Application.Quit();
    }
    
    
    
}
