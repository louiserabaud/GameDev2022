using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfoDisplay : MonoBehaviour
{
    public TMP_Text penalties;
    private int penalties_score = 0;

    void Awake(){
       // player = CameraController.GetPlayerObject();
       // _PlayerController = player.GetComponent<PlayerController>();
       TrafficLightController.CrossedRedLight+=UpdatePenalties;
    }

    void Update(){
       penalties.text = "Penalties: " + penalties_score.ToString();
    }

    void UpdatePenalties(){
        penalties_score+=1;
    }
}
