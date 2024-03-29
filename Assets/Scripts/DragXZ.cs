using UnityEngine;

public class DragXZ : MonoBehaviour
{
    float mZCoord;
    [SerializeField] float Sensitivity;
    Vector3 anchor;
    Rigidbody rb;
    Vector3 movement;
    public PowerCube pC;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (pC.isPoweredOn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
                    {
                        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                        anchor = GetMouseAsWorldPoint();
                    }
                    if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
                    {
                        Vector3 worldPoint = GetMouseAsWorldPoint();
                        movement = (worldPoint - anchor) * Sensitivity;
                        anchor = worldPoint;
                        movement.y = 0.0f;
                        if (Input.GetMouseButton(0))
                        {
                            movement.z = 0.0f;
                        }
                        else if (Input.GetMouseButton(1))
                        {
                            movement.x = 0.0f;
                        }
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (movement.x != 0f || movement.z != 0)
        {
            Vector3 direction = Vector3.Normalize(movement);
            RaycastHit hit;
            if (rb.SweepTest(direction, out hit, movement.magnitude))
            {
                if (hit.distance > 0.01f)
                {
                    movement = direction * (hit.distance - 0.01f);
                }
                else
                {
                    movement = Vector3.zero;
                }
                if (hit.collider.CompareTag("Player"))
                {
                    Vector3 displacement = new Vector3(0f, hit.collider.bounds.extents.y + transform.localScale.y / 2f, 0f);
                    hit.collider.transform.position += displacement;
                }
            }
            rb.MovePosition(transform.position + movement);
        }
        movement = Vector3.zero;
    }
    Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}