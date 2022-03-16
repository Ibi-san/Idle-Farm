using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
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

    void Update()
    {
        _tmp.text = _wheatCollecting.CurrentWheatCollected.ToString() + "/" + _wheatCollecting.MaxWheatCollected.ToString();
    }
}
