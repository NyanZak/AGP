using UnityEngine;
public class RotateObject : MonoBehaviour
{
    public float speed = 10.0f;
    private bool isRotating = true;
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
    public void RotateLeft()
    {
        speed = Mathf.Abs(speed);
    }
    public void RotateRight()
    {
        speed = -Mathf.Abs(speed);
    }
    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}