using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class getMap : MonoBehaviour
{
    public Tilemap map;

    private int width;
    private int height;

    public static Node[,] mapMatrix;

    void Awake()
    {
        width = map.cellBounds.size.x;
        height = map.cellBounds.size.y;
        mapMatrix = new Node[height, width];
        
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                mapMatrix[i, j] = new Node();
                TileBase tile = map.GetTile(new Vector3Int(j - width / 2, -i + height / 2 - 1, 0));
                mapMatrix[i, j].canWalk = tile == null;
                mapMatrix[i, j].selfPos = new Vector2(i, j);
                mapMatrix[i, j].updateH(new Vector2(i, j));
            }
        }
    }
}
