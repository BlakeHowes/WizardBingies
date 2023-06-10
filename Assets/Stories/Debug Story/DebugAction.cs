using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Debug", menuName = "Actions/Debug")]
public class DebugAction : Action
{
    public override void Call() {
        throw new System.NotImplementedException();
    }
}
