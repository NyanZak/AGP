using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class OpenDoor2 : MonoBehaviour
{
    [SerializeField] private float angle = 45f;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private UnityEvent onDoorOpened;
    [SerializeField] private UnityEvent onDoorClosed;
    public GameObject sphereObject;
    private bool doorOpened;
    private bool coroutineAllowed = true;
    private bool isAnimating;
    private Quaternion rotation;
    private bool isFalling;
    private Animator sphereAnimator;
    private void Start()
    {
        doorOpened = false;
        rotation = transform.localRotation;
        sphereAnimator = sphereObject.GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        if (!isAnimating)
        {
            StartCoroutine(doorOpened ? CloseDoor() : OpenTheDoor());

            if (!doorOpened && sphereObject != null)
            {
                StartCoroutine(FallCoroutine());
            }
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

        if (doorOpened && sphereObject != null) // Check if the collectible object is not null
        {
            StartCoroutine(FallCoroutine());
        }
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
    private IEnumerator FallCoroutine()
    {
        yield return new WaitForSeconds(0.25f);
        sphereAnimator.SetBool("IsFalling", true);
        yield return new WaitForSeconds(sphereAnimator.GetCurrentAnimatorStateInfo(0).length);
        isFalling = true;
    }
    public void CollectSphere()
    {
        if (isFalling && sphereObject != null)
        {
            sphereAnimator.SetBool("IsFalling", false);
            sphereAnimator.Play("FinalPositionIdle");
            isFalling = false;
        }
    }
}