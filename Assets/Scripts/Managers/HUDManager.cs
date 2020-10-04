using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Image[] healthBits;
    [SerializeField]  Text gemText;
    private static HUDManager _instance;
    public static HUDManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No UIManager Found!");
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }



    public void UpdateGemCountText(int gemsHeld)
    {
        gemText.text = gemsHeld.ToString() + "G";
    }

    public void UpdateLifeBar(int livesRemaining)
    {
        switch(livesRemaining)
        {
            case(4):
                break;
            case (3):
                healthBits[3].enabled = false;
                break;
            case (2):
                healthBits[2].enabled = false;
                break;
            case (1):
                healthBits[1].enabled = false;
                break;
            case (0):
                healthBits[0].enabled = false;
                break;
        }
    }

   public void KeyNeededPromptEnable()
    {
        transform.GetChild(0).GetComponent<Text>().enabled = true;
    }
    public void KeyNeededPromptDisable()
    {
        transform.GetChild(0).GetComponent<Text>().enabled = false;
    }
}
