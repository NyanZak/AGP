using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OpenBox : MonoBehaviour
{
    [SerializeField] private float distance = 1f;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private UnityEvent onBoxOpened;
    [SerializeField] private UnityEvent onBoxClosed;
    private bool boxOpened;
    private bool coroutineAllowed;
    private Vector3 initialPosition;
    private void Start()
    {
        boxOpened = false;
        coroutineAllowed = true;
        initialPosition = transform.position;
    }
    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(boxOpened ? CloseBox() : OpenTheBox());
        }
    }
    private IEnumerator OpenTheBox()
    {
        coroutineAllowed = false;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos - transform.right * distance;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t / duration);
            yield return null;
        }
        transform.position = endPos;
        boxOpened = true;
        coroutineAllowed = true;
        onBoxOpened.Invoke();
    }
    private IEnumerator CloseBox()
    {
        coroutineAllowed = false;
        Vector3 startPos = transform.position;
        Vector3 endPos = initialPosition;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t / duration);
            yield return null;
        }
        transform.position = endPos;
        boxOpened = false;
        coroutineAllowed = true;
        onBoxClosed.Invoke();
    }
}