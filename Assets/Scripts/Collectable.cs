using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collectable : MonoBehaviour
{
    public int value;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            ScoreManager.instance.IncreaseCoins(value);
        }
    }
}