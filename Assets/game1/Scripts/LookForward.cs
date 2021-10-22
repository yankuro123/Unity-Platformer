using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LookForward : MonoBehaviour
{
    public Transform sightStart, sightEnd;
    public string layer = "Solid";
    public bool needCollsion = true;
    public bool standing;
    public float standingThreshold = 4.0f;

    private bool collision;
    //private Rigidbody2D body2D;
    // Start is called before the first frame update
    void Start()
    {
        //body2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //var absVelY = body2D.velocity.y;

        /*if (absVelY <= standingThreshold)
        {
            standing = true;
        }
        else
        {
            standing = false;
        }
        if (standing)*/
        //{
            /*Vector3 Temp = transform.localScale;*/
            collision = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer(layer));
            Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
            if (collision == needCollsion)
            {
                transform.localScale = new Vector3(transform.localScale.x == 1 ? -1 : 1, 1, 1);
            }
        //}
    }
}
