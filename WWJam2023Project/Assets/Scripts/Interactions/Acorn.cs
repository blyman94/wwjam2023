using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public bool PlayerIsNearAcorn { get; set; } = false;
    public BoolVariable _playerHasAcorn;

    public void OnPlayerInteractResponse()
    {
        if (!PlayerIsNearAcorn)
        {
            return;
        }

        _playerHasAcorn.Value = true;
        Destroy(gameObject);
    }
}
