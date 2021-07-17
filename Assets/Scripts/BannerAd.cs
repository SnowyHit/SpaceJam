using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour , IUnityAdsInitializationListener
{
      [SerializeField] string _androidGameId;
      [SerializeField] string _iOsGameId;
      [SerializeField] bool _testMode = false;
      [SerializeField] bool _enablePerPlacementMode = true;
      private string _gameId;

      void Awake()
      {
          InitializeAds();
      }

      public void InitializeAds()
      {
          _gameId = _androidGameId;
          Advertisement.Initialize(_gameId, _testMode, _enablePerPlacementMode, this);
      }

      public void OnInitializationComplete()
      {
          Debug.Log("Unity Ads initialization complete.");
      }

      public void OnInitializationFailed(UnityAdsInitializationError error, string message)
      {
          Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
      }



         [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

         [SerializeField] string _androidAdUnitId = "Banner_Android";
         [SerializeField] string _iOsAdUnitId = "Banner_iOS";
         string _adUnitId;

         void Start()
         {
             Advertisement.Banner.SetPosition(_bannerPosition);
             BannerLoadOptions options = new BannerLoadOptions
             {
                 loadCallback = OnBannerLoaded,
                 errorCallback = OnBannerError
             };

             // Load the Ad Unit with banner content:
             Advertisement.Banner.Load(_adUnitId, options);
         }


         // Implement code to execute when the loadCallback event triggers:
         void OnBannerLoaded()
         {
             Debug.Log("Banner loaded");

            ShowBannerAd();
         }

         // Implement code to execute when the load errorCallback event triggers:
         void OnBannerError(string message)
         {
             Debug.Log($"Banner Error: {message}");
             // Optionally execute additional code, such as attempting to load another ad.
         }

         // Implement a method to call when the Show Banner button is clicked:
         void ShowBannerAd()
         {
             // Set up options to notify the SDK of show events:
             BannerOptions options = new BannerOptions
             {
                 clickCallback = OnBannerClicked,
                 hideCallback = OnBannerHidden,
                 showCallback = OnBannerShown
             };

             // Show the loaded Banner Ad Unit:
             Advertisement.Banner.Show(_adUnitId, options);
         }


         void HideBannerAd()
         {

             Advertisement.Banner.Hide();
         }

         void OnBannerClicked() { }
         void OnBannerShown() { }
         void OnBannerHidden() { }


     }
