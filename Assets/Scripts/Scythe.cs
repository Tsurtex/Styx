using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    [SerializeField] PlayerC player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.tag == "Destructible"){
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Enemy"){
            GetComponent<AudioSource>().Play();
            int dam = player.damage;
            other.GetComponent<Creature>().takeDam(dam);
        }
    }
}
