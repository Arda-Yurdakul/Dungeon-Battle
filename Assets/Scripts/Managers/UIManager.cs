using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;


//A singleton class
public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public Text PlayerGemCountText;
    public Image selectionImage;

    public static UIManager Instance
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

    public void OpenShop(string gemCount)
    {
        PlayerGemCountText.text = gemCount + "G";
    }

    public void UpdateItemSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

   
}
