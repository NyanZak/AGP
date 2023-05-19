using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShakeOnClick : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;
    private Vector3 originalPos;
    private float shakeTimer = 0f;
    void Start()
    {
        originalPos = transform.position;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsCursorOverObject())
        {
            shakeTimer = shakeDuration;
        }
        if (shakeTimer > 0)
        {
            transform.position = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeTimer -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeTimer = 0f;
            transform.position = originalPos;
        }
    }
    bool IsCursorOverObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                return true;
            }
        }
        return false;
    }
}