using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheat : MonoBehaviour
{
    [Header("Stages of life")]
    [SerializeField] private GameObject _seed;
    [SerializeField] private GameObject _seedling;
    [SerializeField] private GameObject _harvestable;
    [SerializeField] private GameObject _harvested;

    private int _growthIndex = 0;
    private int _maxGrowthIndex = 2;
    public int CurrentGrowthIndex { get { return _growthIndex; } }
    public int MaxGrowthIndex { get { return _maxGrowthIndex; } }

    [SerializeField] private float _timeToGrow;
    private float _growTimer;

    private Garden _garden;
    public bool IsHarvested;

    public enum WheatState
    {
        Seed, Seedling, Harvestable, Harvested
    }

    private WheatState _wheatState;

    private void Start()
    {
        SwitchState(WheatState.Seed);
        IsHarvested = true;
        _growTimer = _timeToGrow;
        _garden = GetComponentInParent<Garden>();
    }

    private void Update()
    {
        _growTimer -= Time.deltaTime;
        if (_growTimer < 0 && _growthIndex < _maxGrowthIndex && _garden.ReadyToGrow == true) 
            Grow();
    }

    private void Grow()
    {
        _growthIndex++;

        if (_growthIndex == 0 && _wheatState == WheatState.Harvested)
        {
            SwitchState(WheatState.Seed);
        }

        if (_growthIndex >= _maxGrowthIndex / 2 && _wheatState == WheatState.Seed)
        {
            SwitchState(WheatState.Seedling);
        }

        if (_growthIndex >= _maxGrowthIndex && _wheatState == WheatState.Seedling)
        {
            SwitchState(WheatState.Harvestable);
            IsHarvested = false;
        }
        _growTimer = _timeToGrow;
    }

    public void Harvest()
    {
        SwitchState(WheatState.Harvested);
        _growthIndex = -1;
        IsHarvested = true;
    }

    private void SwitchState(WheatState stateToSwitch)
    {
        _seed.SetActive(false);
        _seedling.SetActive(false);
        _harvestable.SetActive(false);
        _harvested.SetActive(false);

        switch (stateToSwitch)
        {
            case WheatState.Seed:
                _seed.SetActive(true);
                break;
            case WheatState.Seedling:
                _seedling.SetActive(true);
                break;
            case WheatState.Harvestable:
                _harvestable.SetActive(true);
                break;
            case WheatState.Harvested:
                _harvested.SetActive(true);
                break;
        }

        _wheatState = stateToSwitch;
    }
}
