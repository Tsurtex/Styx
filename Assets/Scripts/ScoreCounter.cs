using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] PlayerC player;
    void Start(){
        setScore();
    }
    void Update(){
        if(ScoreText.text != "You Win!"){
            setScore();
        }
    }
    public void setScore(){
        ScoreText.text = player.score.ToString();
    }
    public void winScore(){
        ScoreText.text = "You Win!"; 
    }
    public void loseScore(){
        ScoreText.text = "You Lose!"; 
    }
}

