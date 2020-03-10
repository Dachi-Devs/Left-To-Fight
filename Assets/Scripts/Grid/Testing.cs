using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private HeatMapVisual heatMapVisual;
    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(16, 9, 6f, new Vector3(-48f, -27f));

        heatMapVisual.SetGrid(grid);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(UtilsClass.GetMouseWorldPosition(), grid.GetValue(UtilsClass.GetMouseWorldPosition()) + 10);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        }
    }
}
