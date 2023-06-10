using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridGraphics
{
    private int width;
    private int height;
    private Tilemap tilemap;

    public GridGraphics(int width,int height,Tilemap tilemap) {
        this.width = width;
        this.height = height;
        this.tilemap = tilemap;
    }

    public void UpdateGraphics(Room[,] rooms) {
        Vector3Int cell = new Vector3Int(0,0,0);
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (!rooms[x, y]) { continue; }
                cell.x = x;
                cell.y = y;
                tilemap.SetTile(cell, rooms[x,y].tile);
            }
        }
    }
}
