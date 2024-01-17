using UnityEngine;

public class CorrectPlatformScript : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2.0f;

    private bool movingToEnd = true;

    private void Update()
    {
        Vector2 target = movingToEnd ? endPoint.position : startPoint.position;

        platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance(platform.position, target) < 0.1f)
        {
            movingToEnd = !movingToEnd;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.position, startPoint.position);
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Gracz dotkn¹³ przeciwnika - zadaj obra¿enia
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.OtrzymajObrazeniaOdPrzeciwnika(1);
            }
        }
    }
}