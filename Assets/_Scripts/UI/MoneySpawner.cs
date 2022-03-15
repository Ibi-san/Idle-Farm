using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _moneyIconPrefab;
    ObjectPool objectPool;

    private void Start()
    {
        objectPool = ObjectPool.Instance;  
    }
    public void SpawnIcon()
    {
        objectPool.SpawnFromPool("MoneyIcon", transform.position, Quaternion.identity, gameObject);
    }
}
