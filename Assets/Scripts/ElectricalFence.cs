using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalFence : MonoBehaviour
{
    private bool isOn = true;
    private float timer = 5f;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(ToggleFence());
    }

    private IEnumerator ToggleFence()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            isOn = !isOn;
            timer = 5f;
            meshRenderer.enabled = isOn;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isOn)
        {
            Destroy(other.gameObject);
        }
    }
}
