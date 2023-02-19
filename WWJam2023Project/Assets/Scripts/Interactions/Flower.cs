using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public bool PlayerIsNearFlower { get; set; } = false;
    public BoolVariable _playerHasFlower;

    public void OnPlayerInteractResponse()
    {
        if (!PlayerIsNearFlower)
        {
            return;
        }

        _playerHasFlower.Value = true;
        Destroy(gameObject);
    }
}
