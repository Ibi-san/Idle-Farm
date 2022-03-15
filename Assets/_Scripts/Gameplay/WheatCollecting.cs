using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatCollecting : MonoBehaviour
{
    [SerializeField] private int _wheatCollected;
    [SerializeField] private int _wheatCollectedLimit = 40;
    public int CurrentWheatCollected { get { return _wheatCollected; } }
    public int MaxWheatCollected { get { return _wheatCollectedLimit; } }

    private bool _sellOnDelay;
    private float _delayTimer;
    private float _delayTime = 0.3f;

    [SerializeField] private GameObject _player;
    private MoneyManagement _moneyManagement;
    [SerializeField] private int _blockCost = 15;

    ObjectPool objectPool;

    private void Start()
    {
        _moneyManagement = _player.GetComponent<MoneyManagement>();
        objectPool = ObjectPool.Instance;
    }

    private void Update()
    {
        if (_sellOnDelay)
        {
            _delayTimer -= Time.deltaTime;
            if (_delayTimer < 0)
                _sellOnDelay = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && _wheatCollected < _wheatCollectedLimit)
        {
            other.gameObject.SetActive(false);
            ChangeCollectedWheat(1);
        }
    }

    public void ChangeCollectedWheat(int amount)
    {
        if (amount < 0)
        {
            if (_sellOnDelay)
                return;
            _sellOnDelay = true;
            _delayTimer = _delayTime;
            _moneyManagement.ChangeMoney(_blockCost);
            objectPool.SpawnFromPool("WheatHay", transform.position + new Vector3(-0.5f, 2f, 0f), Quaternion.identity);
        }
        _wheatCollected = Mathf.Clamp(_wheatCollected + amount, 0, _wheatCollectedLimit);
    }
}
