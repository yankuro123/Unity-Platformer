using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D Target)
     {
        if(Target.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (Target.gameObject.tag == "Deadly" || Target.gameObject.tag == "Eating")
        {
            Destroy(gameObject);
        }
     }

}
