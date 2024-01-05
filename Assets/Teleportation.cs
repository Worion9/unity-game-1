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
        canTeleport = false;

        // Output positions for debugging
        Debug.Log("Entry Point Position: " + entryPoint.position);
        Debug.Log("Exit Point Position: " + exitPoint.position);

        // Calculate the difference vector between entry and exit points
        Vector3 teleportOffset = exitPoint.position - entryPoint.position;

        // Teleport the player from entryPoint to exitPoint
        objectToTeleport.position += teleportOffset;

        // Set a cooldown timer before allowing another teleportation
        Invoke("EnableTeleport", 5f); // 5 seconds cooldown
    }

    void EnableTeleport()
    {
        canTeleport = true;
    }
}
