using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaySize : MonoBehaviour
{
    private WheatCollecting _wheatCollecting;
    [SerializeField] private GameObject _collectableZone;
    private MeshRenderer _hayRender;

    private void Start()
    {
        _wheatCollecting = _collectableZone.GetComponent<WheatCollecting>();
        _hayRender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (_wheatCollecting.CurrentWheatCollected > 0)
        {
            _hayRender.enabled = true;
        }
        else _hayRender.enabled = false;

        if (_wheatCollecting.CurrentWheatCollected == 0)
            gameObject.transform.localScale = new Vector3(0.5f, transform.localScale.y, transform.localScale.z);

        if (_wheatCollecting.CurrentWheatCollected == _wheatCollecting.MaxWheatCollected / 5)
            gameObject.transform.localScale = new Vector3(0.6f, transform.localScale.y, transform.localScale.z);

        if (_wheatCollecting.CurrentWheatCollected == _wheatCollecting.MaxWheatCollected / 4)
            gameObject.transform.localScale = new Vector3(0.7f, transform.localScale.y, transform.localScale.z);

        if (_wheatCollecting.CurrentWheatCollected == _wheatCollecting.MaxWheatCollected / 3)
            gameObject.transform.localScale = new Vector3(0.8f, transform.localScale.y, transform.localScale.z);

        if (_wheatCollecting.CurrentWheatCollected == _wheatCollecting.MaxWheatCollected / 2)
            gameObject.transform.localScale = new Vector3(0.9f, transform.localScale.y, transform.localScale.z);

        if (_wheatCollecting.CurrentWheatCollected == _wheatCollecting.MaxWheatCollected)
            gameObject.transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
    }
}
