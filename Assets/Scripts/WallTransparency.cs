using UnityEngine;
public class WallTransparency : MonoBehaviour
{
    public float fadeSpeed;
    public float fadeAmount;
    private float originalOpacity;
    public Renderer wallRenderer;
    private Material wallMaterial;
    private bool doFade = false;
    private void Start()
    {
        wallMaterial = wallRenderer.material;
        originalOpacity = wallMaterial.color.a;
    }
    private void Update()
    {
        if (doFade)
            FadeNow();
        else
            ResetFade();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doFade = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doFade = false;
        }
    }
    private void FadeNow()
    {
        Color currentColor = wallMaterial.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
        wallMaterial.color = smoothColor;
    }
    private void ResetFade()
    {
        Color currentColor = wallMaterial.color;
        Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b, Mathf.Lerp(currentColor.a, originalOpacity, fadeSpeed * Time.deltaTime));
        wallMaterial.color = smoothColor;
    }
}