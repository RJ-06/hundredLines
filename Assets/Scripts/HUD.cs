using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour{
    [SerializeField] TMP_Text text;
    [SerializeField] Goal[] g;
    void Update(){ text.text = g[0].score + "-" + g[1].score;}
}