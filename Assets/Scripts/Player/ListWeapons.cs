using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWeapons : MonoBehaviour
{
    [SerializeField] private ShootingPlayer _shootingPlayer;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private ButtonSetWeapon _currentWeaponInShop;

    private Weapon _currentWeapon;

    private void OnEnable()
    {
        _currentWeapon = _weapons[0];
    }
    public void SetWeapon(int number, ButtonSetWeapon buttonSetWeapon)
    {
        _currentWeaponInShop.OnButton();
        _currentWeaponInShop = buttonSetWeapon;
        _currentWeapon.gameObject.SetActive(false);
        _shootingPlayer.SetWeapon(_weapons[number]);
        _currentWeapon = _weapons[number];
        _currentWeapon.gameObject.SetActive(true);
    }
}
