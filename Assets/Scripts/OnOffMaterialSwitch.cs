using UnityEngine;

public class OnOffMaterialSwitch : MonoBehaviour
{
    public Renderer renderer;
    public Material onMaterial;
    public Material offMaterial;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void TurnOn()
    {
        renderer.material = onMaterial;
    }

    public void TurnOff()
    {
        renderer.material = offMaterial;
    }
}
