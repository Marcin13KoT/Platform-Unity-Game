using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{

    [Header("UI")]
    public Text messageText;
    public TMP_InputField discordInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    bool loginsucc = false;
    bool registersucc = false;

    [Header("Sound Effects")]
    public AudioSource messageSource;
    public AudioSource errorSource;


    public void RegisterButton() {
        if (passwordInput.text.Length < 6){
            errorSource.PlayOneShot(errorSource.clip, 0.5f);
            messageText.text = "Password too short";
            return;
        }
        if (discordInput.text.Length < 1){
            errorSource.PlayOneShot(errorSource.clip, 0.5f);
            messageText.text = "Please provide Discord username";
            return;
        }

        var request = new RegisterPlayFabUserRequest {
            DisplayName = discordInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageSource.PlayOneShot(messageSource.clip, 0.5f);
        messageText.text = "Signed up and logged in, press play.";
        registersucc = true;
    }

    public void LoginButton(){
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) {
        messageSource.PlayOneShot(messageSource.clip, 0.5f);
        messageText.text = "Logged in, press play.";
        Debug.Log("Successful login/account created");
        loginsucc = true;
    }

    void OnError(PlayFabError error) {
        errorSource.PlayOneShot(errorSource.clip, 0.5f);
        messageText.text = error.ErrorMessage;
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score) {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "MM Mini Game Leaderboard",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Successfull leaderboard sent");
    }

    [Header ("Leaderboard")]
    public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;

    public void GetLeaderboarder()
    {
        var requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "MM Mini Game Leaderboard", MaxResultsCount = 50};
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeadboard, OnError);
    }

    void OnGetLeadboard(GetLeaderboardResult result)
    {
        //Debug.Log(result.Leaderboard[0].StatValue);
        foreach(PlayerLeaderboardEntry player in result.Leaderboard)
        {   
            GameObject tempListing = Instantiate(listingPrefab, listingContainer);
            LearderboardListing LL = tempListing.GetComponent<LearderboardListing>();
            LL.playerPosition.text = (player.Position + 1).ToString();
            LL.playerNameText.text = player.DisplayName;
            LL.playerScoreText.text = player.StatValue.ToString();
            Debug.Log(player.DisplayName + " " + player.StatValue);
        }
    }

    public void StartGame() {
        if (loginsucc | registersucc == true){
            SceneManager.LoadScene(1);
        }
        else {
            errorSource.PlayOneShot(errorSource.clip, 0.5f);
            messageText.text = "You need to login or sign up.";
        }
    }

    public void ReturnButton() {
        leaderboardPanel.SetActive(false);
        return;
    }
}
