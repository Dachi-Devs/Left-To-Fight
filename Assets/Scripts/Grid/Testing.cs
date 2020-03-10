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
        grid = new Grid(80, 45, 5f, new Vector3(-250f, -250f));

        heatMapVisual.SetGrid(grid);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = UtilsClass.GetMouseWorldPosition();
            grid.AddValue(position, 100, 5, 10);
        }
    }
}
