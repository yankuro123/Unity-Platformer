using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60f, 100f);
    public float jetSpeed = 200f;
    public bool standing;
    public float standingThreshold = 10f;
    public float airSpeedMultiplier = 0.3f;
    public float max = 99999999999f;
    public static bool isDead;

    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private PlayerController controller;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            var absVelX = Mathf.Abs(body2D.velocity.x);
            var absVelY = Mathf.Abs(body2D.velocity.y);
            var absHeight = Mathf.Abs(body2D.position.y);

            if (absVelY <= standingThreshold)
            {
                standing = true;
            }
            else
            {
                standing = false;
            }
            var ForceX = 0f;
            var ForceY = 0f;

            if (controller.moving.x != 0)
            {
                if (absVelX < maxVelocity.x)
                {
                    var newSpeed = speed * controller.moving.x;
                    ForceX = standing ? newSpeed : (newSpeed * airSpeedMultiplier);
                    renderer2D.flipX = ForceX < 0;
                }
                animator.SetInteger("AnimState", 1);
            }
            else
            {
                animator.SetInteger("AnimState", 0);
            }

            if (controller.moving.y > 0)
            {
                if (absVelY < maxVelocity.y)
                {
                    if (absHeight > max - 5)
                    {
                        ForceY = -jetSpeed * controller.moving.y * 0.3f;
                    }
                    else
                    {
                        ForceY = jetSpeed * controller.moving.y;
                    }
                }
                animator.SetInteger("AnimState", 2);
            }
            else if (absVelY > 0 && !standing)
            {
                animator.SetInteger("AnimState", 3);
            }
            body2D.AddForce(new Vector2(ForceX, ForceY));
            Vector2 currentPosition = transform.position;
             currentPosition.y = Mathf.Clamp(currentPosition.y, -341, 53f);
             transform.position = currentPosition;

        }
        else
        {
            PlayerController.MovingEnable = false;
        }

    }
}