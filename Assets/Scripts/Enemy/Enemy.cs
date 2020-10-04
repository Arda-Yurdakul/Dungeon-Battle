using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform waypoint1;
    [SerializeField] protected Transform waypoint2;
    [SerializeField] protected GameObject player;

    public GameObject diamondPrefab;
    private Transform currentWaypoint;
    protected Animator anim;
    SpriteRenderer spriteRenderer;

    protected virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

   

    // Update is called once per frame
    protected virtual void Update()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") 
            || this.anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")
            || this.anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            return;
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            FacePlayer();
            return;
        }
        
        Walk();
    }

    protected virtual void Walk()
    {
        if (currentWaypoint == waypoint2)
            spriteRenderer.flipX = false;
        else if (currentWaypoint == waypoint1)
            spriteRenderer.flipX = true;

        if (transform.position == waypoint1.position)
        {
            currentWaypoint = waypoint2;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == waypoint2.position)
        {
            currentWaypoint = waypoint1;
            anim.SetTrigger("Idle");
        }

        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
    }

    protected virtual void Attack()
    {
        print("Base attack");
    }

    protected void CheckDistance()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > 5)
            anim.SetBool("InCombat", false);
    }

    protected void FacePlayer()
    {
        if ((transform.position.x - player.transform.position.x) > 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
}
