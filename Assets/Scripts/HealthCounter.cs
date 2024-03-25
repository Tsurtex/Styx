using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] PlayerC player;
    void Start(){
        setHealth();
    }
    void Update(){
        setHealth();
    }
    public void setHealth(){
        if(player.health >= 0) HealthText.text = player.health.ToString();
        else HealthText.text = "DEAD";
    }
}
