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
    //���ھ��
    public void ShowLeaderBordUI_Ranking()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI0ryr_eIQEAIQAQ");
        Debug.Log("Rank");
    }
    //���ھ� ���
    //public void AddLeaderBoard(int score)
      //  => Social.ReportScore(score, GPGSIds.leaderboard_landing_king,
        //    (bool success) => { });
    //���� UI
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
}
