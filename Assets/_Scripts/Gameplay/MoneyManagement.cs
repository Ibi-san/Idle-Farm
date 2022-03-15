using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManagement : MonoBehaviour
{
    private int _money;
    private int _moneyLimit = 9999;

    public int CurrentMoney { get { return _money; } }
    public void ChangeMoney(int amount)
    {
        _money = Mathf.Clamp(_money + amount, 0, _moneyLimit);
    }
}
