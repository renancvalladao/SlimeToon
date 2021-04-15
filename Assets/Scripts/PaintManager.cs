using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Classe respons�vel por gerenciar as tintas que sujam o ch�o
public class PaintManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private GameObject player;

    [System.Serializable]
    public struct PaintMap
    {
        public string color;
        public Paint paint;
    }

    [SerializeField]
    private List<PaintMap> mapPaints;

    private Dictionary<string, Paint> paintPrefab = new Dictionary<string, Paint>();

    public Dictionary<Vector3Int, Paint> paints = new Dictionary<Vector3Int, Paint>();

    // Transforma a lista de cores do inspector em um mapa
    void Start()
    {
        foreach (var PaintMap in mapPaints) 
        {
            if (!paintPrefab.ContainsKey(PaintMap.color))
            {
                paintPrefab.Add(PaintMap.color, PaintMap.paint);
            }
        }
    }

    // Verifica se o Player possui alguma cor e pinta o tile correspondente � sua posi��o
    private void Update() 
    {
        if (mapManager.GetTileCanPaint(player.transform.position) && player.GetComponent<PlayerController>().playerColor != "Colorless" && !paints.ContainsKey(map.WorldToCell(player.transform.position)))
        {
            Vector3Int gridPosition = map.WorldToCell(player.transform.position);
            PaintTile(gridPosition, player.GetComponent<PlayerController>().playerColor);
        }
    }

    // Fun��o respons�vel por criar o objeto que "suja" o ch�o
    private void PaintTile(Vector3Int tilePosition, string color)
    {
        Paint newPaint = Instantiate(paintPrefab[color]);
        newPaint.transform.position = map.GetCellCenterWorld(tilePosition);
        paints.Add(tilePosition, newPaint);
    }

    // Verifica se o tile na posi��o recebida est� pintado
    public bool IsNextPainted(Vector3 tilePosition)
    {
        Vector3Int gridPosition = map.WorldToCell(tilePosition);
        if (paints.ContainsKey(gridPosition))
        {
            return true;
        }
        return false;
    }

    // Verifica qual a cor do tile recebido
    public string NextColor(Vector3 tilePosition)
    {
        Vector3Int gridPosition = map.WorldToCell(tilePosition);
        return paints[gridPosition].color;
    }
}
