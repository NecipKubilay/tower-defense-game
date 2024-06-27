using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placementSYSTEM : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndýcator, cellIndicator;

    [SerializeField]
    private InputMNGR inputManager;

    [SerializeField]
    private Grid grid;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndýcator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.WorldToCell(gridPosition);
    }
}
