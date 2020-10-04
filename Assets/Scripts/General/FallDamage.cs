using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        Player hitObject = other.GetComponent<Player>();
        if (hitObject != null)
        {
            hitObject.FallDeath();
        }
    }
}
