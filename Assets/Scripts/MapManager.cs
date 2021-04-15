using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach(var tileData in tileDatas)
        {
            foreach(var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    private void Update()
    {

    }

    public bool GetTileCanPaint(Vector2 worldPosition)
    {
        Vector3Int gridPosition = map.WorldToCell(worldPosition);

        TileBase tile = map.GetTile(gridPosition);

        bool canPaint = dataFromTiles[tile].canPaint;

        return canPaint;
    }
}
