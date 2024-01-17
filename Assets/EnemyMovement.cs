using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    private bool movingTowardsA = true;

    void Update()
    {
        MoveBetweenPoints();
    }

    void MoveBetweenPoints()
    {
        Transform targetPoint = movingTowardsA ? pointA : pointB;

        // Oblicz wektor kierunkowy do punktu docelowego
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        // Poruszaj si� w kierunku punktu docelowego
        transform.Translate(direction * speed * Time.deltaTime);

        // Sprawd�, czy przeciwnik osi�gn�� punkt docelowy
        float distanceToTarget = Vector2.Distance(transform.position, targetPoint.position);
        if (distanceToTarget < 0.1f)
            movingTowardsA = !movingTowardsA;
    }
}
