using TapsellPlusSDK;
//using TapsellPlusSDK.models;
using UnityEngine;


public class StandardBannerScene : MonoBehaviour
{
    private const string ZoneID = "651e80de28b2543b3cadc03c";
    private static string _responseId;
    
    public static StandardBannerScene instance;
    
    void Awake()
    {
    	if(instance == null)
    		instance = this;
    	else
    		Destroy(gameObject);
    }



    public void Request()
    {
     
        TapsellPlus.RequestStandardBannerAd(ZoneID, BannerType.Banner320X50,
            tapsellPlusAdModel =>
            {
                Debug.Log("on response " + tapsellPlusAdModel.responseId);

                _responseId = tapsellPlusAdModel.responseId;
            },
            error => { 

                Debug.Log("Error " + error.message); 
                }
        );
    }

    public void Show()
    {
        TapsellPlus.ShowStandardBannerAd(_responseId, Gravity.Bottom, Gravity.Center,
            tapsellPlusAdModel => {
    
                 Debug.Log("onOpenAd " + tapsellPlusAdModel.zoneId); 
                 },
            error => { Debug.Log("onError " + error.errorMessage); }
        );
    }

    public void Hide()
    {
        TapsellPlus.HideStandardBannerAd();
    }

    public void Display()
    {
        TapsellPlus.DisplayStandardBannerAd();
    }

    public void Destroy()
    {
        TapsellPlus.DestroyStandardBannerAd(_responseId);
    }
}