using TapsellPlusSDK;
using UnityEngine;

public class AdManager : MonoBehaviour
{
	public string interstitialVideo = "651d3a4a31a26c187c8fe865";
	private static string _responseId;
	
	
	

    private void Start()
    {

    }
    
    
    public void Request()
    {
    	Debug.Log("request ");
     
        TapsellPlus.RequestInterstitialAd(interstitialVideo,
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
    	Debug.Log("show "); 
        TapsellPlus.ShowInterstitialAd(_responseId,
            tapsellPlusAdModel => {
                
                 Debug.Log("onOpenAd " + tapsellPlusAdModel.zoneId); 
                 },
            tapsellPlusAdModel => { Debug.Log("onCloseAd " + tapsellPlusAdModel.zoneId); },
            error => { Debug.Log("onError " + error.errorMessage); }
        );
    }
}
