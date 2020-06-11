using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    [SerializeField]
    private HeatMapVisual heatMapVisual;
    private Grid<HeatMapGridObject> grid;
    private Grid<StringGridObject> stringGrid;

    // Start is called before the first frame update
    void Start()
    {
        //grid = new Grid<HeatMapGridObject>(32, 18, 5f, new Vector3(-80, -45f), (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));
        //heatMapVisual.SetGrid(grid);

        stringGrid = new Grid<StringGridObject>(20, 10, 8f, new Vector2(-80f, -40f), (Grid<StringGridObject> g, int x, int y) => new StringGridObject(g, x, y));
    }

    void Update()
    {
        Vector3 position = UtilsClass.GetMouseWorldPosition();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 position = UtilsClass.GetMouseWorldPosition();
        //    HeatMapGridObject heatMapGridObject = grid.GetGridObject(position);
        //    if (heatMapGridObject != null)
        //    {
        //        heatMapGridObject.AddValue(5);
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.A)) { stringGrid.GetGridObject(position).AddLetter("A"); ; }
        if (Input.GetKeyDown(KeyCode.B)) { stringGrid.GetGridObject(position).AddLetter("B"); ; }
        if (Input.GetKeyDown(KeyCode.C)) { stringGrid.GetGridObject(position).AddLetter("C"); ; }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { stringGrid.GetGridObject(position).AddNumber("1"); ; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { stringGrid.GetGridObject(position).AddNumber("2"); ; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { stringGrid.GetGridObject(position).AddNumber("3"); ; }
    }
}

public class HeatMapGridObject
{
    private const int MIN = 0;
    private const int MAX = 100;

    private Grid<HeatMapGridObject> grid;
    private int x;
    private int y;
    public int value;

    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue)
    {
        value += addValue;
        value = Mathf.Clamp(value, MIN, MAX);
        grid.TriggerGridObjectChanged(x, y);
    }

    public float GetValueNormalised()
    {
        return (float)value / MAX;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}

public class StringGridObject
{
    private Grid<StringGridObject> grid;
    private int x;
    private int y;

    private string letters;
    private string numbers;

    public StringGridObject(Grid<StringGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        letters = "";
        numbers = "";
    }

    public void AddLetter(string letter)
    {
        letters += letter;
        grid.TriggerGridObjectChanged(x, y);
    }

    public void AddNumber(string number)
    {
        numbers += number;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return letters + "\n" + numbers;
    }
}


