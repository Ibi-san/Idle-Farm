using UnityEngine;
using DG.Tweening;

public class MoneyTransfer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _money;
    private GameObject _target;

    private void OnEnable()
    {
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f ,1);
        _target = GameObject.FindGameObjectWithTag("MoneyScore");
        transform.DOMove(_target.transform.position, _duration).OnComplete(() =>
        {
            _money.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
            {
                _target.transform.DOShakePosition(2f, 10f, 5).OnComplete(() => {
                    _target.transform.DOKill();
                });
                _money.SetActive(false);
            });
        });
    }
}
