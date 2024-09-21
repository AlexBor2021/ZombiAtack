using UnityEngine;
using Agava.YandexGames;
using System;
using System.Collections.Generic;

public class ManagerLeaderBoard : MonoBehaviour
{
    [SerializeField] private RectTransform _container;
    [SerializeField] private int _countViewPlayer;
    [SerializeField] private GameObject _scrollView;
    [SerializeField] private GameObject _loading;
    [SerializeField] private LeaderBoardPrefab _veiw;
    private List<LeaderBoardPrefab> _veiws = new List<LeaderBoardPrefab>();


    private void OnEnable()
    {
#if UNITY_EDITOR
        Clear();
        _veiws.Clear();

        for (int i = 0; i < 10; i++)
        {
            LeaderBoardPrefab leaderBoardPrefab = Instantiate(_veiw, _container);

            _veiws.Add(leaderBoardPrefab);
            
            leaderBoardPrefab.Init("Player" + i, i, _veiws.Count);
        }
        ShowViewLiderBoard(true);
#else
        GetLeaderBoardData(ShowViewLiderBoard);
        AuthtirizeIfNeed();
#endif
    }

    private void GetLeaderBoardData(Action<bool> onComplete)
    {
        Clear();
        _veiws.Clear();

        Leaderboard.GetEntries(SaveManager.LeaderBoardName, OnSucces, OnError, _countViewPlayer, _countViewPlayer, true);
        
        void OnSucces(LeaderboardGetEntriesResponse result)
        {
            foreach (var entries in result.entries)
            {
                string name = entries.player.publicName;

                if (name == null || name == "")
                    name = "Unknown";

                int score = entries.score;

                LeaderBoardPrefab leaderBoardPrefab = Instantiate(_veiw, _container);

                _veiws.Add(leaderBoardPrefab);

                leaderBoardPrefab.Init(name, score, _veiws.Count);
            }

            onComplete?.Invoke(true);
        }

        void OnError(string eror)
        {
            Debug.LogError("Error GetLeaderBoard");
            onComplete?.Invoke(false);
        }
    }
    private void ShowViewLiderBoard(bool isSucces)
    {
        if (isSucces)
        {
            _loading.SetActive(false);
            _scrollView.SetActive(true);
        }
    }

    private void AuthtirizeIfNeed()
    {
        if(PlayerAccount.IsAuthorized == false && PlayerAccount.HasPersonalProfileDataPermission == false)
        {
            if (PlayerAccount.IsAuthorized == false)
            {
                PlayerAccount.Authorize(OnSucces);
            }
            else if (PlayerAccount.HasPersonalProfileDataPermission == false)
            {
                PlayerAccount.RequestPersonalProfileDataPermission();
            }
            void OnSucces()
            {
                PlayerAccount.RequestPersonalProfileDataPermission();
            }
        }
    }

    private void Clear()
    {
        foreach (var veiw in _veiws)
        {
            Destroy(veiw.gameObject);
        }
    }
}
