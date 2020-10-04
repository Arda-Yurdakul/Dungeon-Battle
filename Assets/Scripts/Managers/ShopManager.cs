using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject player;
    private string itemSelected = "fire";
    private int itemCost = 200;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            ShopPanel.SetActive(true);
            UIManager.Instance.OpenShop(other.GetComponent<Player>().gemsHeld.ToString());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ShopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        print("Selected me");
        switch(item)
        {
            case (1):
                UIManager.Instance.UpdateItemSelection(78);
                itemSelected = "fire";
                itemCost = 200;
                break;
            case (2):
                UIManager.Instance.UpdateItemSelection(-24);
                itemSelected = "boot";
                itemCost = 400;
                break;
            case (3):
                UIManager.Instance.UpdateItemSelection(-128);
                itemSelected = "key";
                itemCost = 100;
                break;
        }
    }

    public void BuySelectedItem()
    {
        Player playerRef = player.GetComponent<Player>();
        if (playerRef.gemsHeld > itemCost)
        {
            print("deal");
            playerRef.GemIncrement(-1 * itemCost);
            UIManager.Instance.OpenShop(playerRef.gemsHeld.ToString());
            if (itemCost == 100)
                GameManager.Instance.keyAcquired = true;
        }
    }
}
