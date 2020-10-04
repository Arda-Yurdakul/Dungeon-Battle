using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener

{
    [SerializeField] private GameObject player;

    string gameId = "3832317"; // get this from your unity dashboard
    string placement = "100Gems";
    bool testMode = false;



    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
    }



    public void ShowAd()
    {
        Advertisement.Show(placement);
    }



    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                player.GetComponent<Player>().GemIncrement(100);
                UIManager.Instance.OpenShop(player.GetComponent<Player>().gemsHeld.ToString());
                Debug.Log("100 gems awarded to you");
                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped ad no gems awarded to you");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad video failed to play");
                break;

        }
    }



    public void OnUnityAdsDidError(string message)
    {

    }



    public void OnUnityAdsDidStart(string placementId)
    {

    }



    public void OnUnityAdsReady(string placementId)
    {

    }



} // end of AdsManager

