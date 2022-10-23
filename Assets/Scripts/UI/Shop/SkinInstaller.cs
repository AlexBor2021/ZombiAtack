using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkinInstaller : MonoBehaviour
{
    [SerializeField] private Button _buttonSetSkin;
    [SerializeField] private Button _buttonBuy;
    [SerializeField] private Player _player;
    [SerializeField] private SkinInstaller _skinInstaller;
    [SerializeField] private Material _skinMaterial;

    private const string _fixed = "Fixed";
    private const string _set = "Set";

    public void ActiveButton()
    {
        _buttonSetSkin.gameObject.SetActive(true);
        _buttonBuy.gameObject.SetActive(false);
    }

    public void SetSkin()
    {
        _player.SetSkinMaterial(_skinMaterial, _skinInstaller);
        _buttonSetSkin.GetComponentInChildren<TextMeshProUGUI>().text = _fixed;
        _buttonSetSkin.interactable = false;
        _buttonSetSkin.colors.normalColor.CompareRGB(Color.gray);
    }
    public void SkinTakeOff()
    {
        Debug.Log(1);
        _buttonSetSkin.GetComponentInChildren<TextMeshProUGUI>().text = _set;
        _buttonSetSkin.interactable = true;
        _buttonSetSkin.colors.normalColor.CompareRGB(Color.white);
    }
}
