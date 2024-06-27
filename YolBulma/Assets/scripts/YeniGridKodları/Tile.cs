using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    Animator anim;
    public Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buildSistem.instance.Tiklandimi)
        {
            anim.SetBool("OYNA", true);
           
        }
        if (!buildSistem.instance.Tiklandimi)
        {
            anim.SetBool("OYNA", false);
            
        }
    }
}
