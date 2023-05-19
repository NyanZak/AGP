using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class OpenDoor : MonoBehaviour
{
    [SerializeField] private float angle = 45f;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private UnityEvent onDoorOpened;
    [SerializeField] private UnityEvent onDoorClosed;
    private bool doorOpened;
    private bool coroutineAllowed = true;
    private bool isAnimating;
    private Quaternion rotation;
    private void Start()
    {
        doorOpened = false;
        rotation = transform.localRotation;
    }
    private void OnMouseDown()
    {
        if (!isAnimating)
        {
            StartCoroutine(doorOpened ? CloseDoor() : OpenTheDoor());
        }
    }
    private IEnumerator OpenTheDoor()
    {
        isAnimating = true;
        float t = 0f;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0f, -angle, 0f);
        while (t < duration)
        {
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = endRotation;
        doorOpened = true;
        isAnimating = false;
        onDoorOpened.Invoke();
    }
    private IEnumerator CloseDoor()
    {
        isAnimating = true;
        float t = 0f;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = rotation;
        while (t < duration)
        {
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = endRotation;
        doorOpened = false;
        isAnimating = false;
        onDoorClosed.Invoke();
    }
}