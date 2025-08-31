using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;
    // Interstitial Ad
    [SerializeField] string _androidAdUnitIdInterstitial = "Interstitial_Android";
    [SerializeField] string _iOSAdUnitIdInterstitial = "Interstitial_iOS";
    string _adUnitIdInterstitial;
    //
    //Rewarded Ad
    [SerializeField] string _androidAdUnitIdRewarded = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitIdRewarded = "Rewarded_iOS";
    string _adUnitIdRewarded = null;
    public bool isRewardedReady = false;
    public Button rewardedBtn;

    void Awake()
    {
        // Get the Interstitial Ad Unit ID for the current platform:
        _adUnitIdInterstitial = (Application.platform == RuntimePlatform.IPhonePlayer)
        ? _iOSAdUnitIdInterstitial
        : _androidAdUnitIdInterstitial;

        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
    _adUnitIdRewarded = _iOSAdUnitIdRewarded;
#elif UNITY_ANDROID
        _adUnitIdRewarded = _androidAdUnitIdRewarded;
#endif

        InitializeAds();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
    _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
    _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif


        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }



    public void OnInitializationComplete()
    {
        LoadAdInterstitial();
        LoadAdRewarded();

        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == _adUnitIdInterstitial)
        {
            Debug.Log("Interstitial Ad loaded.");
        }
        else if (placementId == _adUnitIdRewarded)
        {
            isRewardedReady = true;
            rewardedBtn.interactable = true;
        }

    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == _adUnitIdRewarded)
        {
            Debug.Log("Reward win.");
        }
    }
    //
    #region Interstitial
    public void LoadAdInterstitial()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitIdInterstitial);
        Advertisement.Load(_adUnitIdInterstitial, this);
    }

    public void ShowAdInterstitial()
    {
        // Then show the ad:
        Advertisement.Show(_adUnitIdInterstitial, this);
        //LoadAdInterstitial();
    }
    #endregion

    #region Rewarded
    public void LoadAdRewarded()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitIdRewarded);
        Advertisement.Load(_adUnitIdRewarded, this);
    }
    public void ShowAdRewarded()
    {
        // Disable the button:
        isRewardedReady = false;
        rewardedBtn.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitIdRewarded, this);
        //LoadAdRewarded();
    }
    #endregion
}
