using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Story", menuName = "Log/Story")]
public class Story : ScriptableObject {
    [Range(0,100)] public int progressCoefficient;
    [SerializeField]public List<Card> cards;
}
[System.Serializable]
public struct Card {
    public string text;
    public List<Character> characters;
    public List<Option> options;
}
public abstract class Action : ScriptableObject {
    public string text;
    public abstract void Call();
}
[System.Serializable]
public class Option {
    public string text;
    public List<Action> actions;
    public void DestroyCard() {

    }
}

[CreateAssetMenu(fileName = "Character", menuName = "Log/Character")]
public class Character : ScriptableObject {
    public Sprite sprite;
    public string bio;
}
