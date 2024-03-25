using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreatureAI : MonoBehaviour
{

    //blackboard=======================================================
    [SerializeField] public PlayerC targetCreature; //the creature we are piloting
    
    [SerializeField] public Creature myCreature;

    [Header("Config")]
    public LayerMask obstacles;
    public float sightDistance = 5;


    

    //State machine====================================================
    //States go here
    CreatureAIState currentState;
    public CreatureAIIdleState idleState{get; private set;}
    public CreatureAIHugState hugState{get; private set;}
    public CreatureAIPatrolState patrolState{get; private set;}
    //public CreatureAIInvestigateState investigateState{get; private set;}


    public void ChangeState(CreatureAIState newState){

        currentState = newState;

        currentState.BeginStateBase();
    }


    // Start is called before the first frame update
    void Start()
    {
        idleState = new CreatureAIIdleState(this);
        hugState = new CreatureAIHugState(this);
        patrolState = new CreatureAIPatrolState(this);

        currentState = idleState;


    }


    void FixedUpdate()
    {
        currentState.UpdateStateBase(); //work the current state

    }

    public PlayerC GetTarget(){

        if(Vector3.Distance(transform.position,targetCreature.transform.position) < sightDistance){
            return targetCreature;
        }
        else return null;
    }

    public void SetColor(Color c){
        myCreature.GetComponent<SpriteRenderer>().color = c;
    }





}