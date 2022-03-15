using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Garden : MonoBehaviour
{
    [SerializeField] private List<Wheat> _wheatList = new List<Wheat>();
    public bool ReadyToGrow = true;
    private Wheat _wheat;

    private void Start()
    {
        foreach (Transform child in transform)
        {
            _wheat = child.GetComponent<Wheat>();
            _wheatList.Add(_wheat);
        }
    }

    private void Update()
    {
        ReadyToGrow = _wheatList.All(g => g.IsHarvested == true);
    }
}
