using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheatScore : MonoBehaviour
{
    [SerializeField] private  TMP_Text _tmp;
    [SerializeField] private GameObject _collectableZone;
    private WheatCollecting _wheatCollecting;
    void Start()
    {
        _wheatCollecting = _collectableZone.GetComponent<WheatCollecting>();
        _tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _tmp.text = _wheatCollecting.CurrentWheatCollected.ToString() + "/" + _wheatCollecting.MaxWheatCollected.ToString();
    }
}
