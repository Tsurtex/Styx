using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    [SerializeField]  PlayerC character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            input.x += -1;
            input.y += .5f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input.x += 1;
            input.y -= .5f;
        }

        if(Input.GetKey(KeyCode.W)){
            input.y += 1;
            
        }

        if(Input.GetKey(KeyCode.S)){
            input.y -= 1;
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.Swing();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            character.speed = 4;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            character.speed = 2;
        }

        character.MoveCreatureRb(input);
    }
}
