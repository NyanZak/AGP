using UnityEngine;
public class PlayerRespawn : MonoBehaviour
{
    public Transform lastCheckpoint;
    public void Respawn()
    {
        transform.position = lastCheckpoint.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KillZone")
        {
            Respawn();
        }

        if (other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = other.transform;
        }
    }
}