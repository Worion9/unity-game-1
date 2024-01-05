using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform entryPoint;
    public Transform exitPoint;

    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            Teleport(other.transform);
        }
    }

    void Teleport(Transform objectToTeleport)
    {
        Debug.Log("Teleporting player");

        // Teleport the player from entryPoint to exitPoint
        objectToTeleport.position = exitPoint.position;

        // Set a cooldown timer before allowing another teleportation
        canTeleport = false;
        Invoke("EnableTeleport", 5f); // 5 seconds cooldown
    }

    void EnableTeleport()
    {
        canTeleport = true;
    }
}
