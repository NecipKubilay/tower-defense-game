using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameManager : MonoBehaviour
{
    [SerializeField] AudioSource Muzýk;

    /*public int gold;
    public Text goldDisplay;


    private Building buildingToPlace;
    public GameObject grid;


    public CustomCursor customCursor;


    public Tile[] tiles;


    public GameObject Taretprefab;
    GameObject prefabInstance;*/ 
    public GameObject[] pausepanel;
    private bool panelIsActive;
    
    // Start is called before the first frame update
    void Start()
    { 
        // pausepanel = GameObject.Find("PausePanel");

    }

    // Update is called once per frame
    void Update()
    {
        //goldDisplay.text = gold.ToString();
        
        Pause();
        


        /*if (Input.GetMouseButtonDown(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;

            float nearestDistance = float.MaxValue;
            foreach (Tile tile in tiles)
            {
                float dist = Vector3.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestTile = tile;
                }
            }*/
            //if (nearestTile.isOccupied==false) 
            //{
            //    Instantiate(buildingToPlace,nearestTile.transform.position,Quaternion.identity);
            //    buildingToPlace = null;
            //    nearestTile.isOccupied = true;
            //    grid.SetActive(false);
            //    Cursor.visible = true;
            //}

        // }


        // prefabInstance.transform.position = Input.mousePosition;
    }

    /*public void BuyBuilding(Building building)
    {


        if (gold >= building.cost)
        {
            GameObject prefabInstance = Instantiate(Taretprefab);
            prefabInstance.transform.position = Input.mousePosition;

            //customCursor.gameObject.SetActive(true);
            //customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            //Cursor.visible = false;


            gold -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }*/

    public void DevamEtOnClick()
    {
        pausepanel[0].SetActive(false);
        pausepanel[1].SetActive(true);
        Time.timeScale = 1f;
        panelIsActive = false;
    }

    public void CikisOnClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    
    
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!panelIsActive)
            {
                pausepanel[0].SetActive(true);
                pausepanel[1].SetActive(false);
                Time.timeScale = 0f;
                panelIsActive = true;
            }
            else
            {
                pausepanel[0].SetActive(false);
                pausepanel[1].SetActive(true);
                Time.timeScale = 1f;
                panelIsActive = false;
            }
            
        }
    }

    void ses()
    {
        Muzýk.Play();
    }
}
