using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour 
{
    public Room selectedRoom;
    [NonSerialized]public int width;
    [NonSerialized] public int height;
    public static MouseManager i;
    void Awake() {
        i = this;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            var mousePos = MousePositionOnGrid();
            if (!InBounds(mousePos)) { selectedRoom = null;  return; }
            if(mousePos.y < 8) { goto Place; }
            if(GridManager.i.GetRoom(mousePos - new Vector3Int(0, 1))){ goto Place; }
            if (GridManager.i.GetRoom(mousePos - new Vector3Int(1, 0))) { goto Place; }
            if (GridManager.i.GetRoom(mousePos - new Vector3Int(-1, 0))) { goto Place; }
            if (GridManager.i.GetRoom(mousePos - new Vector3Int(0, -1))) { goto Place; }
            return;
            Place:
            PlaceRoom();
            GridManager.i.UpdateGraphics();
        }
    }

    public bool InBounds(Vector3Int position) {
        if (position.x < 0 || position.x >= width || position.y < 0 || position.y >= height) {
            return false;
        }
        return true;
    }

    public void PlaceRoom() {
        if(selectedRoom == null) { return; }
        var mousePos = MousePositionOnGrid();
        GridManager.i.SetRoom(mousePos, selectedRoom);
    }

    public Vector3Int MousePositionOnGrid() {
        var mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseposInt = new Vector3Int(Mathf.FloorToInt(mousepos.x), Mathf.FloorToInt(mousepos.y), 0);
        return mouseposInt;
    }
}
