using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfoDisplay : MonoBehaviour
{
    public Transform playerPosition;
    public TMP_Text penalties;
    [SerializeField] GameObject player;
    PlayerController _PlayerController;


    void Awake(){
        playerPosition = GameObject.Find("Player").transform;
        _PlayerController = player.GetComponent<PlayerController>();
      
    }

    void Update(){
        penalties.text = "Penalties: " + _PlayerController.penalties.ToString();
    }
}
