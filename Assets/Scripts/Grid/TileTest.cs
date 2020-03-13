using UnityEngine;
using CodeMonkey.Utils;

public class TileTest : MonoBehaviour
{
    [SerializeField] private TilemapVisual tilemapVisual;
    private Tilemap tilemap;
    private Tilemap.TilemapObject.TilemapSprite tilemapSprite;

    void Start()
    {
        tilemap = new Tilemap(20, 10, 10, Vector3.zero);

        tilemap.SetTilemapVisual(tilemapVisual);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = UtilsClass.GetMouseWorldPosition();

            tilemap.SetTilemapSprite(mouseWorldPos, tilemapSprite);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.None;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.Ground;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.Path;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.Grass;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            tilemapSprite = Tilemap.TilemapObject.TilemapSprite.Water;
        }
    }
}
