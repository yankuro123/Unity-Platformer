using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienC : MonoBehaviour
{
    public float attackDelay = 3.0f;
    public GameObject projectile;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if(attackDelay != 0)
        {
            StartCoroutine(OnAttack());
        }
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        Fire();
        yield return new WaitForSeconds(0.45f);
        Back();
        StartCoroutine(OnAttack());
    }

    void Fire()
    {
        animator.SetInteger("AnimState", 1);
    }
    void Back()
    {
        animator.SetInteger("AnimState", 0);
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnFire()
    {
        if(projectile != null)
        {
            var clone = Instantiate(projectile, transform.position, Quaternion.identity);

        }
    }
}
