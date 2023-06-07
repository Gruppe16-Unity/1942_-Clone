using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public RuleTile islandRuleTile;
    public TileBase oceanTile;
    public int mapWidth = 10;
    public int mapHeight = 10;
    public int islandCount = 5;

    private void Start()
    {
        GenerateTilemap();
    }

    private void GenerateTilemap()
    {
        // Set the entire tilemap to the ocean tile
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        for (int i = 0; i < allTiles.Length; i++)
        {
            allTiles[i] = oceanTile;
        }
        tilemap.SetTilesBlock(bounds, allTiles);

        // Add islands
        for (int i = 0; i < islandCount; i++)
        {
            int x = Random.Range(0, mapWidth);
            int y = Random.Range(0, mapHeight);
            Vector3Int tilePosition = new Vector3Int(x, y, 0);
            tilemap.SetTile(tilePosition, islandRuleTile);
        }
    }
}
