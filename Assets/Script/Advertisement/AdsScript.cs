using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsScript : MonoBehaviour
{
    Database theDB;



    void Awake()
    {
        Advertisement.Initialize("4669525", false);

    }

    private void Start()
    {
        theDB = FindObjectOfType<Database>();
    }
    
    

    public void ShowAd()
    {
        if (Advertisement.IsReady())
        {
            if(theDB.adCount % 4 == 0)
            {
                Advertisement.Show("Interstitial_Android");
            }
        }
    }

    public void ShowRewardAd()
    {
        if (Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultedAds };
            Advertisement.Show("Rewarded_Android", options);
        }
    }

    void ResultedAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("광고 보기에 실패했습니다.");
                break;
            case ShowResult.Skipped:
                Debug.Log("광고를 스킵했습니다.");
                break;
            case ShowResult.Finished:
                // 광고 보기 보상 기능 
                Debug.Log("광고 보기를 완료했습니다.");
                break;
        }
    }


}
