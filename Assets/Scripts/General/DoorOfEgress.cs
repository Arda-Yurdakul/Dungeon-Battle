using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOfEgress : MonoBehaviour
{
    public GameObject winPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance.keyAcquired)
        {
            winPanel.SetActive(true);
        }
        else
        {
            HUDManager.Instance.KeyNeededPromptEnable();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        HUDManager.Instance.KeyNeededPromptDisable();
    }
}
