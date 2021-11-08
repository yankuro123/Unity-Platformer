using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienB : MonoBehaviour
{
    public string scene;

    private Animator animator;
    private bool Ready;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (Ready)
            {
                var explode = target.GetComponent<Explode>();
                explode.OnExplode();
                Invoke("Die", 1.0f);
            }
            else
            {
                animator.SetInteger("AnimState", 1);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        Ready = false;
        animator.SetInteger("AnimState", 0);
    } 
    void Attack()
    {
        Ready = true;
    }
    void Die()
    {
        SceneManager.LoadScene(scene);
    }
}
