using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModeSwitchUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _uiAttack;
    [SerializeField] private List<GameObject> _uiNotAttack;
    

    public event UnityAction StartedAttack;

    public void SetUIAttack()
    {
        SwitchObject(_uiAttack, true);
        SwitchObject(_uiNotAttack, false);
        StartedAttack?.Invoke();
    }
    public void SetUIShop()
    {
        SwitchObject(_uiAttack, false);
        SwitchObject(_uiNotAttack, true);
    }
    private void SwitchObject(List<GameObject> list, bool enable)
    {
        foreach (var item in list)
        {
            item.SetActive(enable);
        }
    }
    public void DeleteInList(GameObject gameObject)
    {
        foreach (var item in _uiNotAttack)
        {
            if (item == gameObject)
            {
                _uiNotAttack.Remove(item);
                return;
            }
        }
    }
}
