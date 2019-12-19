using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    public Text kill;
    public Text combo;
    void Start()
    {
        kill.text = GameDirector.resultKill2.ToString();
        combo.text = GameDirector.resultCombo2.ToString();
    }


    void Update()
    {
        
    }
}
