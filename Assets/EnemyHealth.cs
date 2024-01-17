using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Dodajemy delegat i zdarzenie do obs³ugi œmierci przeciwnika
    public delegate void EnemyDeathAction();
    public static event EnemyDeathAction OnEnemyDeath;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with player");

        if (collision.gameObject.CompareTag("Player") && IsCollisionFromTop(collision))
        {
            Die();

            // Wywo³ujemy zdarzenie, ¿e przeciwnik umar³
            OnEnemyDeath?.Invoke();
        }
    }

    bool IsCollisionFromTop(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Debug.Log("Contact normal: " + contact.normal);
            if (contact.normal.y <= -0.5f)  // Sprawdzamy, czy normalna wskazuje w dó³
            {
                return true;
            }
        }
        return false;
    }

    void Die()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}
