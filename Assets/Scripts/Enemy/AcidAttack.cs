using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidAttack : MonoBehaviour
{
   [SerializeField] private GameObject acid;
   public void MassiveAttack()
    {
        Instantiate(acid);
    }

    
}
