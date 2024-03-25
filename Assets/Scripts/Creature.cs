using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] int health = 10;
    [SerializeField] int speed = 1;
    [SerializeField] int Power = 5;
    [SerializeField] int Sval;
    [SerializeField] PlayerC player;
    [Header("For Boss")]
    [SerializeField] bool ifboss = false;
    [SerializeField] ScreenFader fader;
    [SerializeField] ScoreCounter scoreCounter;
    Rigidbody2D rb;
    // Start is called before the first frame update
    
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
 

    public void takeDam(int Dam){
        if(player.health>0){
            health -= Dam;
            if(health <= 0f){
                Destroy(gameObject);
                player.score += Sval;
                player.health += Sval;
                if(ifboss){
                    scoreCounter.winScore();
                    winLevel();
                }
            }
        }
    }    
    
    void OnTriggerEnter2D(Collider2D other){//do damage
        if(other.gameObject.tag == "Player"){
            
            player.takeDam(Power);
        }
    }

    private void winLevel(){
        fader.FadeToColor("MainMenu");
    }


    public void MoveCreatureRb(Vector3 direction){

        Vector3 currentVelocity = Vector3.zero;

        rb.velocity = currentVelocity + (direction * speed);
        if(rb.velocity.x < 0){
            transform.localScale = new Vector3(1,1,1);
        }
        else if (rb.velocity.x > 0){
            transform.localScale = new Vector3(-1,1,1);
        }
     }


    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreatureRb(direction.normalized);
    }

    public void Stop(){
        Vector3 push = Vector3.zero;
        MoveCreatureRb(push);
    }
}
