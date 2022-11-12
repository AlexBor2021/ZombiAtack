using System.Collections;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

    public class YandexGamesSDK : MonoBehaviour
    {
        [SerializeField]
        private Text _authorizationStatusText;

        [SerializeField]
        private Text _personalProfileDataPermissionStatusText;

        [SerializeField]
        private InputField _playerDataTextField;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        public void OnShowInterstitialButtonClick()
        {
            InterstitialAd.Show();
        }

        public void OnShowVideoButtonClick()
        {
            VideoAd.Show();
        }

        public void OnAuthorizeButtonClick()
        {
            PlayerAccount.Authorize();
        }

        public void OnRequestPersonalProfileDataPermissionButtonClick()
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
        }

        public void OnGetProfileDataButtonClick()
        {
            PlayerAccount.GetProfileData((result) =>
            {
                string name = result.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";
                Debug.Log($"My id = {result.uniqueID}, name = {name}");
            });
        }

        public void OnSetLeaderboardScoreButtonClick()
        {
            Leaderboard.SetScore("PlaytestBoard", Random.Range(1, 100));
        }

        public void OnGetLeaderboardEntriesButtonClick()
        {
            Leaderboard.GetEntries("PlaytestBoard", (result) =>
            {
                Debug.Log($"My rank = {result.userRank}");
                foreach (var entry in result.entries)
                {
                    string name = entry.player.publicName;
                    if (string.IsNullOrEmpty(name))
                        name = "Anonymous";
                    Debug.Log(name + " " + entry.score);
                }
            });
        }

        public void OnGetLeaderboardPlayerEntryButtonClick()
        {
            Leaderboard.GetPlayerEntry("PlaytestBoard", (result) =>
            {
                if (result == null)
                    Debug.Log("Player is not present in the leaderboard.");
                else
                    Debug.Log($"My rank = {result.rank}, score = {result.score}");
            });
        }

        public void OnSetPlayerDataButtonClick()
        {
            PlayerAccount.SetPlayerData(_playerDataTextField.text);
        }

        public void OnGetPlayerDataButtonClick()
        {
            PlayerAccount.GetPlayerData((data) => _playerDataTextField.text = data);
        }

        public void OnGetDeviceTypeButtonClick()
        {
            Debug.Log($"DeviceType = {Device.Type}");
        }

        public void OnGetEnvironmentButtonClick()
        {
            Debug.Log($"Environment = {JsonUtility.ToJson(YandexGamesSdk.Environment)}");
        }
    }
