using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selling : MonoBehaviour
{
    [SerializeField] private GameObject _collectableZone;
    private WheatCollecting _wheatCollecting;

    [SerializeField] private GameObject _barn;
    private float _haySpeed = 2f;

    private void Start()
    {
        _wheatCollecting = _collectableZone.GetComponent<WheatCollecting>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SellZone") && _wheatCollecting.CurrentWheatCollected != 0)
        {
            _wheatCollecting.ChangeCollectedWheat(-1);
        }
            
        if (other.CompareTag("Hay"))
        {
            other.transform.Translate(Vector3.left * _haySpeed * Time.deltaTime);
        }
    }
}
