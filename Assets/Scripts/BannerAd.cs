using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour , IUnityAdsInitializationListener
{
      [SerializeField] string _androidGameId;
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
          BannerLoadOptions options = new BannerLoadOptions
          {
              loadCallback = OnBannerLoaded,
              errorCallback = OnBannerError
          };

          Debug.Log("Unity Ads initialization complete.");
           Advertisement.Banner.Load(_androidAdUnitId, options);
      }

      public void OnInitializationFailed(UnityAdsInitializationError error, string message)
      {
          Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
      }



         [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

         [SerializeField] string _androidAdUnitId = "Banner_Android";

         void Start()
         {
             Advertisement.Banner.SetPosition(_bannerPosition);

             // Load the Ad Unit with banner content:

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

             // Show the loaded Banner Ad Unit:
             Advertisement.Banner.Show(_androidAdUnitId);
             Debug.Log("Showing Banner");
         }


         void HideBannerAd()
         {

             Advertisement.Banner.Hide();
         }

         void OnBannerClicked() { }
         void OnBannerShown() { }
         void OnBannerHidden() { }


     }
