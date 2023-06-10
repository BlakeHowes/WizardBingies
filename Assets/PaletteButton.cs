using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteButton : MonoBehaviour
{
    public Room room;

    public void SelectRoom() {
        MouseManager.i.selectedRoom = room;
    }

    public void OnValidate() {
        if (room) {
            if(room.tile)GetComponent<Image>().sprite = room.tile.m_DefaultSprite;
        }
    }
}
