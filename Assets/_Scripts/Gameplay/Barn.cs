using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    private WheatCollecting _wheatCollecting;
    [SerializeField] private GameObject _collectableZone;
    [SerializeField] private MeshRenderer _sellZone;

    private void Start()
    {
        _wheatCollecting = _collectableZone.GetComponent<WheatCollecting>();
    }

    private void Update()
    {
        if (_wheatCollecting.CurrentWheatCollected == 0)
            _sellZone.enabled = false;
        else _sellZone.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hay"))
            collision.gameObject.SetActive(false);
    }
}
