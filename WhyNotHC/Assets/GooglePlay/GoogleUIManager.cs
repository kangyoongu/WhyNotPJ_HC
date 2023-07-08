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
    //���ھ��
    public void ShowLeaderBordUI_Ranking()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI0ryr_eIQEAIQAQ");
        Debug.Log("Rank");
    }
    //���ھ� ���
    public void AddLeaderBoard(int score)
        => Social.ReportScore(score, GPGSIds.leaderboard_landing_king,
            (bool success) => { });
    //���� UI
    public void ShowAchiv()
    {
        Social.ShowAchievementsUI();
        Debug.Log("achiv");
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
