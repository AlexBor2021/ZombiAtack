using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YandexSDKInshilize : MonoBehaviour
{
    private BasaData _basaData;
    public BasaData BaseData => _basaData;
    
    public bool InputSystemKeyBoard;


    private IEnumerator  Start()
    {
         DontDestroyOnLoad(this.gameObject);
#if UNITY_WEBGL && !UNITY_EDITOR

        yield return YandexGamesSdk.Initialize();
        PlayerAccount.GetPlayerData(OnInitialized, OnError);
        void OnInitialized(string data)
        {
            Debug.Log("Initialized");
            _basaData = JsonUtility.FromJson<BasaData>(data);
            SceneManager.LoadScene(1);
        }

        void OnError(string error)
        {
            Debug.Log(error);
            _basaData = new BasaData();
            SceneManager.LoadScene(1);
        }
#else
        _basaData = new BasaData();
        SceneManager.LoadScene(1);
#endif
        yield return null;

        InputSystemKeyBoard = SetInputGameKeyBoard();
    }
    public bool SetInputGameKeyBoard()
    {
#if UNITY_WEBGL && YANDEX_GAMES && !UNITY_EDITOR
        return Device.Type == Agava.YandexGames.DeviceType.Desktop;
#endif
        return SystemInfo.deviceType ==  UnityEngine.DeviceType.Desktop;
    }

}
