using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameManager : MonoBehaviour
{
    /*public int gold;
    public Text goldDisplay;


    private Building buildingToPlace;
    public GameObject grid;


    public CustomCursor customCursor;


    public Tile[] tiles;


    public GameObject Taretprefab;
    GameObject prefabInstance;*/ 
    public GameObject pausepanel;
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


   
    
    
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!panelIsActive)
            {
                pausepanel.SetActive(true);
                Time.timeScale = 0f;
                panelIsActive = true;
            }
            else
            {
                pausepanel.SetActive(false);
                Time.timeScale = 1f;
                panelIsActive = false;
            }
            
        }
    }
}
