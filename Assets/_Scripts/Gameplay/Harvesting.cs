using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvesting : MonoBehaviour
{
    private Wheat _wheat;
    
    private void Start()
    {
        _wheat = GetComponentInParent<Wheat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scythe"))
            _wheat.Harvest();
            
    }
}
