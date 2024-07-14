using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class buildSistem : MonoBehaviour
{

    [Header("ses----------------")]
    [SerializeField] AudioSource yerlestirme;


    public UnityEvent Yerlestirme;

    //------------------------------------------


    // CinemachineBrain bileþeni
    public CinemachineBrain brain;

    // Aktif kamera
    private CinemachineVirtualCamera activeCamera;

    // Kullanýlabilir kameralar
    public CinemachineVirtualCamera[] cameras;


    //------------------------------------------

    public Canvas myCanvas;
    Animator myAnimator;

    public GameObject[] demoObjects;
    public GameObject[] objects;
    public GameObject[] grids;
    GameObject pendingObject;


    Vector3 nearestGridPosition;
    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField]
    private LayerMask layermask;


    [SerializeField] private Material[] materials;


    public bool canPlace;

    [SerializeField] int yerlestirilecekObjeIndex;
    public bool Tiklandimi;

    
    public static buildSistem instance;
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

     
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
            
    }


    private void FixedUpdate()
    {

    }
    public void PlaceObject()
    {
        //if (pendingObject == null)
        //{
        //    return;
        //}



        //if (Input.GetMouseButtonDown(0))
        //{
        //    pendingObject.transform.position = nearestGridPosition;
        //    pendingObject = null;
        //}

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            canPlace = true;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            canPlace = false;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layermask))
        {
            pos = hit.point;


            //-----------------------PLACE OBJECT-------------------------
            if (pendingObject != null)
            {
                pendingObject.transform.position = pos;

                nearestGridPosition = FindNearestGridPosition(pendingObject.transform.position);

                pendingObject.transform.position = nearestGridPosition;

                //pendingObject.GetComponent<MeshRenderer>().material = materials[2];

                if (Input.GetMouseButtonDown(0) && checkPlacement.instance.koyabilirmi)
                {
                    
                    Instantiate(objects[yerlestirilecekObjeIndex], nearestGridPosition, Quaternion.identity);
                    //Debug.Log("çalýþtý");
                    Destroy(pendingObject);
                    pendingObject = null;
                    Tiklandimi = false;

                    Yerlestirme.Invoke();
                    yerlestirme.Play();
                }

            }
            //------------------------------------------------------------

        }

    }


    public void selectObject1(int index)
    {
        
        pendingObject = Instantiate(demoObjects[index], pos, transform.rotation);
        yerlestirilecekObjeIndex = index;
        Tiklandimi = true;
    }

    public void selectObject2(int index)
    {

        pendingObject = Instantiate(demoObjects[index], pos, transform.rotation);
        yerlestirilecekObjeIndex = index;
        Tiklandimi = true;
    }

    public void selectObject3(int index)
    {

        pendingObject = Instantiate(demoObjects[index], pos, transform.rotation);
        yerlestirilecekObjeIndex = index;
        Tiklandimi = true;
    }


    private Vector3 FindNearestGridPosition(Vector3 objectPosition)
    {
        Vector3 nearestGridPosition = Vector3.zero;
        float nearestDistance = Mathf.Infinity;

        // Her bir gridin konumuna olan uzaklýðý hesapla
        foreach (GameObject grid in grids)
        {
            float distance = Vector3.Distance(objectPosition, grid.transform.position);

            // En yakýn gridin konumunu ve uzaklýðýný güncelle
            if (distance < nearestDistance)
            {
                nearestGridPosition = grid.transform.position;
                nearestDistance = distance;
            }
        }

        return nearestGridPosition;
    }




    

}
