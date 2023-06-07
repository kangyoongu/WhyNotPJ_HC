using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.UI;
using GooglePlayGames.BasicApi;

public class GoogleUIManager : MonoBehaviour
{
    public Text score;
    public void ShowLeaderBordUI_Ranking()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI0ryr_eIQEAIQAQ");
        Debug.Log("Rank");
    }

    public void AddLeaderBoard(int score)
        => Social.ReportScore(score, GPGSIds.leaderboard_landing_king,
            (bool success) => { });

    public void ShowAchiv()
    {
        Social.ShowAchievementsUI();
    }
}
