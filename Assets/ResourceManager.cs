using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager i;

    public int potionP;
    public int botanyP;
    public int darkP;
    public int charmsP;
    public int astrologicalP;

    public TextMeshProUGUI potionPText;
    public TextMeshProUGUI botanyPText;
    public TextMeshProUGUI darkPText;
    public TextMeshProUGUI charmsPText;
    public TextMeshProUGUI astrologicalPText;

    public void FixedUpdate() {
        potionPText.text = potionP.ToString();
        botanyPText.text = botanyP.ToString();
        darkPText.text = darkP.ToString();
        charmsPText.text = charmsP.ToString();
        astrologicalPText.text = astrologicalP.ToString();
    }

    public void ChangePotionPValue(int value) {
        potionP += value;
        if (potionP < 0) { potionP = 0; }
    }

    public void Awake() {
        i = this;
    }
}
