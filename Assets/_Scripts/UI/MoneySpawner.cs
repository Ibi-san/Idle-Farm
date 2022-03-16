using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _moneyIconPrefab;
    private ObjectPool _objectPool;

    private void Start()
    {
        _objectPool = ObjectPool.Instance;  
    }
    public void SpawnIcon()
    {
        _objectPool.SpawnFromPool("MoneyIcon", transform.position, Quaternion.identity, gameObject);
    }
}
