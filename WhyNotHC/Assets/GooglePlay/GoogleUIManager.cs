using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

public class GoogleUIManager : MonoBehaviour
{
    public Text score;
    [SerializeField] GameObject save;
    //스코어보드
    public void ShowLeaderBordUI_Ranking()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI0ryr_eIQEAIQAQ");
        Debug.Log("Rank");
    }
    //스코어 등록
    public void AddLeaderBoard(int score)
        => Social.ReportScore(score, GPGSIds.leaderboard_landing_king,
            (bool success) => { });
    //업적 UI
    public void ShowAchiv()
    {
        Social.ShowAchievementsUI();
        Debug.Log("achiv");
    }
    public void SaveUI()
    {
        save.SetActive(true);
    }
    public void SaveUIClose()
    {
        save.SetActive(false);
    }

    //save
    //public void Save()
    //{
    //    DataManager dataManager = new DataManager()
    //    {
    //        //mat = PlayerPrefs.GetInt("onmat") ,
    //        //coin = PlayerPrefs.GetInt("coin"),
    //        //bestScore  = PlayerPrefs.GetInt("onmat"),
    //        //isBuySkin = PlayerPrefs.GetInt("onmat"),


    //    };
    //   string json =  JsonConvert.SerializeObject(dataManager);
    //byte[] datas=    Encoding.UTF8.GetBytes(json);
    //}

}
