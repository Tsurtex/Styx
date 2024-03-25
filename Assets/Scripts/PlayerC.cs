using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerC : MonoBehaviour
{

    [Header("Stats")]
    [SerializeField] public float speed = 1f;
    [SerializeField] public int health;
    [SerializeField] public int score = 0;
    [SerializeField] float meleespeed;
    [SerializeField] public int damage = 5;

    [Header("Flavor")]
    [SerializeField] string creatureName = "V";
    [SerializeField] GameObject Weapon;

    [Header("Other")]
    [SerializeField] public GameObject body;
    [SerializeField] private Animator anim;
    [SerializeField] ScreenFader fader;
    [SerializeField] ScoreCounter scoreCounter;
    Rigidbody2D rb;
    float timeUntilMelee;

    // Start is called before the first frame update
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

     public void MoveCreatureRb(Vector3 direction){
        Vector3 currentVelocity = Vector3.zero;
        if(health > 0){       
            rb.velocity = (currentVelocity) + (direction * speed);
            if(rb.velocity.x < 0){
                body.transform.localScale = new Vector3(1,1,1);
            }
            else if (rb.velocity.x > 0){
                body.transform.localScale = new Vector3(-1,1,1);
            }
        }
    }
 
    public void Swing(){
        anim.SetTrigger("Attack");
        GetComponent<AudioSource>().Play();
        timeUntilMelee = meleespeed;
     }


    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreatureRb(direction.normalized);
    }

    public void Stop(){
        MoveCreatureRb(Vector3.zero);
    }
    public void takeDam(int Dam){
        health -= Dam;
        Debug.Log("Health: " + health);
        if(health <= 0f){
            scoreCounter.loseScore();
            fader.FadeToColor("MainMenu");
        }
    }
     

}
