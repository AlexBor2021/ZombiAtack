using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualGame : MonoBehaviour
{
    [SerializeField] private GameObject _panelMAnual;
    [SerializeField] private List<Image> images;
    [SerializeField] private Button _faorward;
    [SerializeField] private Button _back;

    private int _currentImage = 0;

    private void Start()
    {
        Invoke("StartManual", 3f);
    }
    private void StartManual()
    {
        Time.timeScale = 0;
        _panelMAnual.SetActive(true);
        _back.interactable = false;
    }
    private void Update()
    {
        if (_currentImage == images.Count - 1)
        {
            _faorward.interactable = false;
        }
        else
        {
            _faorward.interactable = true;
        }
        if (_currentImage == 0)
        {
            _back.interactable = false;
        }
        else
        {
            _back.interactable = true;
        }
    }

    public void NextImage()
    {
        images[_currentImage].gameObject.SetActive(false);
        _currentImage++;
        images[_currentImage].gameObject.SetActive(true);
    }
    public void BackImage()
    {
        images[_currentImage].gameObject.SetActive(false);
        _currentImage--;
        images[_currentImage].gameObject.SetActive(true);
    }
    public void Exit()
    {
        Time.timeScale = 1;
        _panelMAnual.gameObject.SetActive(false);
    }

}  
