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
    [SerializeField] private GameObject _hayPool;
    private ObjectPool _objectPool;

    [SerializeField] private MoneySpawner _moneySpawner;
    private void Start()
    {
        _moneyManagement = _player.GetComponent<MoneyManagement>();
        _objectPool = ObjectPool.Instance;
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
            _objectPool.SpawnFromPool("WheatHay", transform.position + Vector3.up * 2f + Vector3.left, Quaternion.identity, _hayPool);
            _moneySpawner.SpawnIcon();
        }
        _wheatCollected = Mathf.Clamp(_wheatCollected + amount, 0, _wheatCollectedLimit);
    }
}
