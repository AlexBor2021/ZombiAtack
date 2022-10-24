using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private List<BoardDoor> _boards;
    [SerializeField] private Destructible _destructible;
    [SerializeField] private Animator _animator;
    [SerializeField] private Button _fixButton;
    [SerializeField] private FinishWave _finishWave;
    
    private int _cuurentBoard = 0;
    private float _healthForPersent;
    private float _check = 0;
    private const string _fix = "Fix";
    private void OnEnable()
    {
        _healthForPersent = _destructible.Health;
        _finishWave.FinishedWave += SetFixButton;
    }
    private void OnDisable()
    {
        _finishWave.FinishedWave -= SetFixButton;
    }

    private void Update()
    {
        if (_boards.Count == _cuurentBoard)
            return;

        if (_destructible.Health <= SetPersent(_boards[_cuurentBoard].PersentForDestroy) && _check != _destructible.Health)
        {
            DestroyDoor(_cuurentBoard);
            _check = _destructible.Health;
        }
    }
    public void SetFixButton()
    {
        if (_destructible.Health != _destructible.MaxHealth)
        {
            _fixButton.gameObject.SetActive(true);
        }
    }
    public void RecoveryDoor()
    {
        _animator.enabled = true;
        _destructible.RecoveryHealth();
        _cuurentBoard = 0;
    }
    public void OffAnimator()
    {
        _animator.enabled = false;
    }
    private float SetPersent(float persentCurent)
    {
        float persent = _healthForPersent / 100 * persentCurent;
        return persent;
    }
    private void DestroyDoor(int numberBoard)
    {
        _boards[numberBoard].Destroy();
        _cuurentBoard++;
    }
}
