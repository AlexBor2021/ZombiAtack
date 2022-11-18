using UnityEngine;
using UnityEngine.UI;

public class ButtonSetWeapon : MonoBehaviour
{
    [SerializeField] private ListWeapons _listWeapons;
    [SerializeField] private int _numberWeponPlayers;
    [SerializeField] private Button _takeWeaponButton;
    [SerializeField] private Image _markerTakeWeapon;

    public void SetWeapon()
    {
        _listWeapons.SetWeapon(_numberWeponPlayers, this);
        _markerTakeWeapon.enabled = true;
        _takeWeaponButton.interactable = false;
    }

    public void OnButton()
    {
        _takeWeaponButton.interactable = true;
        _markerTakeWeapon.enabled = false;
    }
}
