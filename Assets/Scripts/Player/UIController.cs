using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PlayerController controller;
    public TMP_Text penalty;
    public TMP_Text speed;

    void Start()
    {
        penalty.text = "Penalty: 0";
        speed.text = "0";
    }

    void Update()
    {
        var s = (int)controller.GetSpeed();
        speed.text = s.ToString() + " KM";
        var p = (int)controller.penalty;
        penalty.text = "Penalty: " + p.ToString();
    }
}
