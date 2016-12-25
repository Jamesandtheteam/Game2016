using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {
    public int coinsCollected;
    public int totalCoinCount;

    void Awake()
    {
        totalCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void FixedUpdate()
    {
        coinsCollected = totalCoinCount - GameObject.FindGameObjectsWithTag("Coin").Length;
    }
}
