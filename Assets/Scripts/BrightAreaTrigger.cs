using UnityEngine;
public class BrightAreaTrigger : MonoBehaviour
{
    public float maxLightIntensity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            Light light = GetComponent<Light>();
            Debug.Log(light.intensity);
            if (light != null && light.intensity >= maxLightIntensity)
            {
                DragXZ cube = other.GetComponent<DragXZ>();
                Destroy(other.gameObject);
            }
        }
    }
}