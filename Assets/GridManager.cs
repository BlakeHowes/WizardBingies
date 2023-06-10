using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public int width;
    public int height;
    public static GridManager i;
    public Room[,] rooms;
    public GridGraphics graphics;

    public Tilemap tilemap;

    public Room testRoom;
    private float tickTimer;
    public void Awake() {
        i = this;
        Initialize();
    }

    public void SetRoom(Vector3Int position,Room room) {
        rooms[position.x, position.y] = room;
    }

    public Room GetRoom(Vector3Int position) {
        return rooms[position.x, position.y];
    }

    public void UpdateGraphics() {
        graphics.UpdateGraphics(rooms);
    }

    void OnDrawGizmosSelected() {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 1, 1, 0.2f);
        Gizmos.DrawCube(new Vector3(width / 2, height / 2), new Vector3(width, height));
    }

    public void Update() {

        if (Input.GetKeyDown(KeyCode.Z)) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    rooms[x, y] = testRoom;
                }
            }
            graphics.UpdateGraphics(rooms);
        }

        tickTimer += Time.deltaTime;
        if(tickTimer >= 1) {
            tickTimer = 0;
            Tick();
        }
    }

    public void Tick() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (rooms[x,y])rooms[x, y].Call();
            }
        }
    }

    public void Initialize() {
        graphics = new GridGraphics(width, height,tilemap);
        MouseManager.i.width = width;
        MouseManager.i.height = height;
        rooms = new Room[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                rooms[x, y] = null;
            }
        }
    }
}
