using UnityEngine;
public class RadioScript : MonoBehaviour, IPowerable
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void EnablePower()
    {
        audioSource.Play();
    }
    public void DisablePower()
    {
        audioSource.Stop();
    }
}