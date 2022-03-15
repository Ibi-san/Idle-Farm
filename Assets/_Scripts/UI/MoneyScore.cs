using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmp;
    [SerializeField] private GameObject _player;
    private MoneyManagement _moneyManagement;
    void Start()
    {
        _moneyManagement = _player.GetComponent<MoneyManagement>();
        _tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _tmp.text = _moneyManagement.CurrentMoney.ToString();
    }
}
