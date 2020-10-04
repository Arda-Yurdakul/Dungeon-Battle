using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();
        Health = base.health;
        speed = 1;
    }

    protected override void Update()
    {
        base.Update();
        CheckDistance();
    }

    public void Damage(int amount)
    {
        anim.Play("Death");
        GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
        diamond.GetComponent<Diamond>().setWorth(gems);
    }
}
