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
    [SerializeField] private Image _imageSkin;
    [SerializeField] private Material _skinMaterial;
    [SerializeField] private TextMeshProUGUI _fixed;
    [SerializeField] private TextMeshProUGUI _set;

    private void Awake()
    {
        _imageSkin.color = _skinMaterial.color;
    }

    public void ActiveButton()
    {
        _buttonSetSkin.gameObject.SetActive(true);
        _buttonBuy.gameObject.SetActive(false);
    }

    public void SetSkin()
    {
        _player.SetSkinMaterial(_skinMaterial, this);
        _set.gameObject.SetActive(false);
        _fixed.gameObject.SetActive(true);
        _buttonSetSkin.interactable = false;
        _buttonSetSkin.colors.normalColor.CompareRGB(Color.gray);
    }
    public void SkinTakeOff()
    {
        _set.gameObject.SetActive(true);
        _buttonSetSkin.interactable = true;
        _buttonSetSkin.colors.normalColor.CompareRGB(Color.white);
    }
}
