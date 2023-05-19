using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RespawnOnDestroy : MonoBehaviour
{
    public float respawnTime = 5f;
    private Vector3 originalPosition;
    private bool isDestroyed = false;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void InvokeRespawn()
    {
        isDestroyed = true;
        gameObject.SetActive(false);
        Invoke("Respawn", respawnTime);
    }

    public void Respawn()
    {
        if (isDestroyed)
        {
            transform.position = originalPosition;
            gameObject.SetActive(true);
            isDestroyed = false;
        }
    }    
}
