using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    PlayerAnim playerAnim;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    SpriteRenderer swordArcRenderer;
    float horizontalInput;

    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private GameObject cineMachine;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private bool grounded = false;
    [SerializeField] private float playerSpeed = 2.5f;
    [SerializeField] private int health = 5;
    public int gemsHeld = 0;

    
    int IDamageable.Health { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnim>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        swordArcRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnim.AmIDead())
            return;
        horizontalInput = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(horizontalInput * playerSpeed, rigidbody.velocity.y);
        grounded = Physics2D.Raycast(transform.position, Vector2.down, .7f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);


        Attack();
        Jump();
        Flip();
        playerAnim.SetMove(horizontalInput);
    }

    void Flip()
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            swordArcRenderer.flipX = true;
            swordArcRenderer.flipY = true;
        }
            

        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            swordArcRenderer.flipX = false;
            swordArcRenderer.flipY = false;
        }
           
    }

    void Jump()
    {
#if UNITY_EDITOR
       if(Input.GetKeyDown("space"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            playerAnim.SetJumping(true);
        }
#else
         if ((CrossPlatformInputManager.GetButtonDown("A_Button")) && grounded == true)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            playerAnim.SetJumping(true);
        }
#endif

        if (rigidbody.velocity.y <= 0.05f && grounded == true)
            playerAnim.SetJumping(false);
    }

    void Attack()
    {
        if (( CrossPlatformInputManager.GetButtonDown("B_Button")) && grounded == true )
        {
            playerAnim.SetAttackTrigger();
            playerAnim.SetSwordArcTrigger();
        }
    }

 

    void IDamageable.Damage(int amount)
    {
        health -= amount;
        HUDManager.Instance.UpdateLifeBar(health);
        if (health == 0)
        {
            playerAnim.SetDeathTrigger();
            Invoke("EnableDeathScreen", 1.5f);
        }
        else if (health > 0)
            playerAnim.SetHitTrigger();
    }

    public void FallDeath()
    {
        health = 0;
        HUDManager.Instance.UpdateLifeBar(3);
        HUDManager.Instance.UpdateLifeBar(2);
        HUDManager.Instance.UpdateLifeBar(1);
        HUDManager.Instance.UpdateLifeBar(0);
        playerAnim.SetDeathTrigger();
        cineMachine.SetActive(false);
        Invoke("EnableDeathScreen", 1.5f);
    }

    public void GemIncrement(int worth)
    {
        gemsHeld += worth;
        HUDManager.Instance.UpdateGemCountText(gemsHeld);
    }

    public void EnableDeathScreen()
    {
        DeathPanel.SetActive(true);
    }
}
