using UnityEngine;
using TMPro;

public class LeaderBoardPrefab : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _countWave;
    [SerializeField] private TextMeshProUGUI _number;
    

    public void Init(string name, int countwave, int number)
    {
        _name.text = name;
        _countWave.text = countwave.ToString();
        _number.text = number.ToString();
        Debug.Log(number);
    }
}
