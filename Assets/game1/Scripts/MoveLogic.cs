using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLogic : MonoBehaviour
{
    public float speed = 20.0f;

    private Rigidbody2D body2D;
    private bool standing;
    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        body2D.velocity = new Vector2(transform.localScale.x,0) * speed;
        body2D.AddForce(new Vector2(0, -1500));
    }

}
        