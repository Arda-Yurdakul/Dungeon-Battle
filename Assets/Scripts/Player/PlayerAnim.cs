using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    Animator swordAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMove(float move)
    {
        anim.SetFloat("MoveSpeed",Mathf.Abs(move));
    }

    public void SetJumping(bool jumping)
    {
        anim.SetBool("Jumping", jumping);
    }

    public void SetAttackTrigger()
    {
        anim.SetTrigger("Attack");
    }

    public void SetSwordArcTrigger()
    {
        swordAnim.SetTrigger("SwordArc");
    }

    public void SetHitTrigger()
    {
        anim.SetTrigger("Hit");
    }

    public void SetDeathTrigger()
    {
       anim.SetTrigger("Death");
    }

    public bool AmIDead()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("Death");
    }
}
