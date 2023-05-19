using UnityEngine;
public class BrightAreaTrigger1 : MonoBehaviour
{
    public float maxLightIntensity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                Material material = renderer.material;
                material.EnableKeyword("_EMISSIONS");
                Debug.Log(material.ToString());
                if (material != null && material.HasProperty("_EmissionColor"))
                {
                    Color emissiveColor = material.GetColor("_EmissionColor");
                    Debug.Log(emissiveColor);
                    float emissiveIntensity = emissiveColor.maxColorComponent;
                    Debug.Log(emissiveIntensity);
                    if (emissiveIntensity >= maxLightIntensity)
                    {
                        DragXZ cube = other.GetComponent<DragXZ>();
                        if (cube != null && cube.pC.isPoweredOn)
                        {
                            RespawnOnDestroy respawnScript = other.gameObject.GetComponent<RespawnOnDestroy>();
                            respawnScript.InvokeRespawn(); 
                            }
                        }
                    }
                }
            }
     }
}