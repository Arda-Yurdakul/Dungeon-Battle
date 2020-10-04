using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int worth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Player>().GemIncrement(worth);
        }
    }

    public void setWorth(int num)
    {
        worth = num;
    }
}
