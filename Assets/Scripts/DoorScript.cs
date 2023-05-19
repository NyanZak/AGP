using UnityEngine;
public class DoorScript : MonoBehaviour, IPowerable
{
    public OpenDoorTest doorScript;
    public void EnablePower()
    {
        doorScript.OpenDoor();
    }
    public void DisablePower()
    {
        doorScript.CloseDoor();
    }
}