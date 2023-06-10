using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Classroom", menuName = "Rooms/Classroom")]
public class Classroom : Room
{
    public int magicGenerated;
    public override void Call() {
        ResourceManager.i.ChangePotionPValue(magicGenerated);
        Debug.Log("This is a classroom!");
    }
}
