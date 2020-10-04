using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        IDamageable hitObject = other.GetComponent<IDamageable>();
        if (hitObject != null)
        {
            hitObject.Damage(1);
        }
    }
}
