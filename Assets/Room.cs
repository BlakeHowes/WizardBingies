using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Room : ScriptableObject
{
    public RuleTile tile;
    public abstract void Call();
}
