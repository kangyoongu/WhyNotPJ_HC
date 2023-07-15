using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using Newtonsoft.Json;
using System.Text;
using Unity.VisualScripting;
using Google.Play.AppUpdate;
using System.Collections;
using Google.Play.Common;
using Google.Play.Review;

public class GPManager : MonoBehaviour
{
    public string Token;
    public string Error;
    public TMP_Text LogText;
    [SerializeField] TMP_Text coin;
    [SerializeField] GameOver gameOver;
    [SerializeField] CustomManager customManager;
    DataManager dataManager = new DataManager();
    AppUpdateManager appUpdateManager;
    string json;



    void Awake()
    {
        //var config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
        PlayGamesPlatform.Activate();
        StartCoroutine(CheckForUpdate());
    }
    IEnumerator Init()
    {
        yield return new WaitForSeconds(1f);
        appUpdateManager = new AppUpdateManager();
    }

    async void Start()
    {
        GooglePlayGames.PlayGamesPlatform.Activate();
        await UnityServices.InitializeAsync();
        await LoginGooglePlayGames();
        await SignInWithGooglePlayGamesAsync(Token);
    }
    //Fetch the Token / Auth code
    public Task LoginGooglePlayGames()
    {
        var tcs = new TaskCompletionSource<object>();
        PlayGamesPlatform.Instance.Authenticate((success) =>
        {
            if (success == SignInStatus.Success)
            {
                Debug.Log("Login with Google Play games successful.");
                PlayGamesPlatform.Instance.RequestServerSideAccess(true, code =>
                {
                    Debug.Log("Authorization code: " + code);
                    Token = code;
                    // This token serves as an example to be used for SignInWithGooglePlayGames
                    tcs.SetResult(null);
                });
            }
            else
            {
                Error = "Failed to retrieve Google play games authorization code";
                Debug.Log("Login Unsuccessful");
                tcs.SetException(new Exception("Failed"));
            }
        });
        return tcs.Task;
    }


    async Task SignInWithGooglePlayGamesAsync(string authCode)
    {
        try
        {
            await AuthenticationService.Instance.SignInWithGooglePlayGamesAsync(authCode);
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}"); //Display the Unity Authentication PlayerID
            Debug.Log("SignIn is successful.");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    //public void LogOut()
    //{
    //    ((PlayGamesPlatform)Social.Active).SignOut();
    //}

    ISavedGameClient SavedGame()
    {
        return PlayGamesPlatform.Instance.SavedGame;
    }
    public void LoadCloud()
    {
        SavedGame().OpenWithAutomaticConflictResolution("mysave",
            DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood, LoadGame);
    }
    void LoadGame(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            SavedGame().ReadBinaryData(game, LoadData);
        }
    }
    void LoadData(SavedGameRequestStatus status, byte[] loadedData)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            string data = Encoding.UTF8.GetString(loadedData);
            dataManager = JsonConvert.DeserializeObject<DataManager>(data);
            
            PlayerPrefs.SetInt("coin", dataManager.coin);
            PlayerPrefs.SetInt("best", dataManager.bestScore);
            customManager.keys["coin"] = dataManager.coin;
            coin.text = dataManager.coin.ToString();
            gameOver.Main_Best.text = dataManager.bestScore.ToString();
            json = PlayerPrefs.GetString("data"); // 스킨 data
            dataManager.skins = JsonConvert.DeserializeObject<DataManager>(json).skins;// list에 넣기
            for (int i = 0; i < dataManager.skins.Count; i++)
            {
                customManager.Work(0, dataManager.skins[i]);
            }
            
            LogText.text = "로드 성공";
        }
        else
        {
            LogText.text = "로드 실패";
        }
    }

    
    public void SaveCloud()
    {
            print("저장");
            dataManager.mat = PlayerPrefs.GetInt("onmat");
            dataManager.isBuySkin = PlayerPrefs.GetInt($"isBuy{dataManager.engName[dataManager.mat]}");
            dataManager.coin = PlayerPrefs.GetInt("coin");
            dataManager.bestScore = PlayerPrefs.GetInt("best");
            string data = JsonConvert.SerializeObject(dataManager);
            PlayerPrefs.SetString("data", data);

            print(JsonConvert.SerializeObject(dataManager, Formatting.Indented));
            SavedGame().OpenWithAutomaticConflictResolution("mysave", DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood, SaveGame);
    }
    public void SaveGame(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            print(PlayerPrefs.GetInt("onmat"));
            print(PlayerPrefs.GetInt($"isBuy{dataManager.engName[dataManager.mat]}"));
            dataManager.mat = PlayerPrefs.GetInt("onmat");
            dataManager.isBuySkin = PlayerPrefs.GetInt($"isBuy{dataManager.engName[dataManager.mat]}");
            dataManager.coin = PlayerPrefs.GetInt("coin");
            dataManager.bestScore = PlayerPrefs.GetInt("best");

            string json = JsonConvert.SerializeObject(dataManager);
            var update = new SavedGameMetadataUpdate.Builder().Build();
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            SavedGame().CommitUpdate(game, update, bytes, SaveData);
        }
    }
    void SaveData(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            LogText.text = "저장 성공";
        }
        else { LogText.text = "저장 실패"; }
    }

    public void DeleteCloud()
    {
        SavedGame().OpenWithAutomaticConflictResolution("mysave", DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLongestPlaytime, DeleteGame);
    }
    void DeleteGame(SavedGameRequestStatus status, ISavedGameMetadata game)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            SavedGame().Delete(game);
            LogText.text = "삭제 성공";
        }
        else { LogText.text = "삭제 실패"; }
    }

    IEnumerator CheckForUpdate()
    {
        yield return StartCoroutine(Init());
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appUpdateInfoOperation = appUpdateManager.GetAppUpdateInfo();
        yield return appUpdateInfoOperation;

        if(appUpdateInfoOperation.IsSuccessful)
        {
            var appUpdateInfoResult = appUpdateInfoOperation.GetResult();

            if(appUpdateInfoResult.UpdateAvailability == UpdateAvailability.UpdateAvailable)
            {
                Debug.Log(UpdateAvailability.UpdateAvailable);
            }
            else
            {
                Debug.Log("No Update");
            }

            var appUpdateOptions = AppUpdateOptions.ImmediateAppUpdateOptions();
            StartCoroutine(StartImmediateUpdate(appUpdateInfoResult, appUpdateOptions));
        }
        else
        {
            Debug.Log(appUpdateInfoOperation.Error);
        }
    }
    IEnumerator StartImmediateUpdate(AppUpdateInfo appUpdateInfoOp_i, AppUpdateOptions appUpdateOptions_i)
    {
        var startUpdateRequest = appUpdateManager.StartUpdate(
            appUpdateInfoOp_i,
            appUpdateOptions_i
            );
        yield return startUpdateRequest;
    }
    public void Review()
    {
        var reviewManager = new ReviewManager();
        var playReviewInfoAsyncOperation = reviewManager.RequestReviewFlow();

        playReviewInfoAsyncOperation.Completed += playReviewInfoAsync =>
        {
            if (playReviewInfoAsync.Error == ReviewErrorCode.NoError)
            {
                var playReviewInfo = playReviewInfoAsync.GetResult();
                reviewManager.LaunchReviewFlow(playReviewInfo);
            }
            else
            {
                Debug.Log(playReviewInfoAsync.Error);
            }
        };
    }
}
