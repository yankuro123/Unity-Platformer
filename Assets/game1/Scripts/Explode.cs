using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explode : MonoBehaviour
{
    public Debris debris;
    public int totalDebris = 10;
    public string scene;
    public float timer;

    //private bool starttimer = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {
            OnExplode();

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deadly")
        {

            OnExplode();
            Invoke("Die", 1.0f);
            Debug.Log("Triggered");
            
        }
    }
    public void OnExplode()
    {
        var t = transform;

        for (int i = 0; i < totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(debris, t.position, Quaternion.identity) as Debris;
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
            body2D.AddForce(Vector3.up * Random.Range(500, 2000));
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }
    void Die()
    {
        SceneManager.LoadScene(scene);
    }
}

