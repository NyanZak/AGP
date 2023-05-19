using UnityEngine;
public class LightScript : MonoBehaviour, IPowerable
{
    public Light lightComponent;
    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }
    public void EnablePower()
    {
        lightComponent.enabled = true;
    }
    public void DisablePower()
    {
        lightComponent.enabled = false;
    }
}