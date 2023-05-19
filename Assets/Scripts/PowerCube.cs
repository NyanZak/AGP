using UnityEngine;

public class PowerCube : MonoBehaviour
{
    public GameObject[] powerableObjects;
    public Renderer cubeRenderer;
    public Material onMaterial; 
    public Material offMaterial;

    public bool isPoweredOn = true;
    private bool isInsideTrigger = false; 
    private GameObject triggeredObject;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        UpdateCubeMaterial();
    }

    private void Update()
    {
        if (isInsideTrigger && Input.GetKeyDown(KeyCode.E) && triggeredObject != null)
        {
            TogglePower();
        }
    }

    private void TogglePower()
    {
        IPowerable powerable = triggeredObject.GetComponent<IPowerable>();
        if (powerable != null)
        {
            if (isPoweredOn)
            {
                powerable.EnablePower();
                Debug.Log("Power Enabled on " + triggeredObject.name);
            }
            else
            {
                powerable.DisablePower();
                Debug.Log("Power Disabled on " + triggeredObject.name);
            }
        }

        isPoweredOn = !isPoweredOn;
        UpdateCubeMaterial();
    }

    private void UpdateCubeMaterial()
    {
        if (isPoweredOn)
        {
            cubeRenderer.material = onMaterial;
            Debug.Log("Cube Material Set to On");
        }
        else
        {
            cubeRenderer.material = offMaterial;
            Debug.Log("Cube Material Set to Off");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (IsPowerableObject(other.gameObject))
        {
            isInsideTrigger = true;
            triggeredObject = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == triggeredObject)
        {
            isInsideTrigger = false;
            triggeredObject = null;
        }
    }

    private bool IsPowerableObject(GameObject obj)
    {
        foreach (GameObject powerableObject in powerableObjects)
        {
            if (obj == powerableObject)
            {
                return true;
            }
        }
        return false;
    }
}
