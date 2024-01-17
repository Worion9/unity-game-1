using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private static int currentHealth;
    public static string healthString = "5 / 5";

    public float knockbackForce = 5f;
    private Rigidbody2D playerRigidbody;

    private bool isInvincible = false;
    public float invincibleDuration = 0.5f;
    private float invincible = 0.5f;

    public AudioClip damageSound;
    private AudioSource audioSource;

    void Start()
    {
        currentHealth = maxHealth;
        playerRigidbody = GetComponent<Rigidbody2D>();

        // Rejestrujemy funkcj� HandleEnemyDeath do obs�ugi zdarzenia OnEnemyDeath
        EnemyHealth.OnEnemyDeath += HandleEnemyDeath;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = damageSound;
    }

    void Update()
    {
        // Aktualizuj czas niewra�liwo�ci gracza
        if (isInvincible)
        {
            invincible -= Time.deltaTime;

            if (invincible <= 0f)
            {
                isInvincible = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Knockback(other.transform.position);
            if (!isInvincible)
            {
                TakeDamage(1); // Mo�esz dostosowa� warto�� obra�e�
                MakeInvincible();
                audioSource.Play();
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("ouch hp: " + currentHealth);
        healthString = currentHealth + " / 5";

        // Dodaj dowolne dodatkowe logiki zwi�zane z otrzymywaniem obra�e�, np. animacje, efekty d�wi�kowe itp.

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    static async Task Die()
    {
        // Dodaj dowolne dodatkowe logiki zwi�zane ze �mierci� gracza, np. restart gry, wy�wietlenie ekranu �mierci itp.
        Debug.Log("czekanie rozpocz�te");
        await WaitForHalfSecond();
        if (currentHealth <= 0)
        {
            Debug.Log("Player died");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        Debug.Log("czekanie zako�czone");
    }

    void Knockback(Vector3 enemyPosition)
    {
        // Ustawiamy warto�� y wektora kierunkowego na 1, aby wskazywa� w kierunku g�rnym
        Vector2 knockbackDirection = new Vector2(0f, 1f);

        // Resetuj pr�dko�� pionow� gracza, aby unikn�� wp�ywu grawitacji na odbicie
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);

        // Dodaj si�� odrzutu do gracza w kierunku g�rnym
        playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    void MakeInvincible()
    {
        isInvincible = true;
        invincible = invincibleDuration; // Ustaw czas niewra�liwo�ci na 0.5 sekundy (mo�esz dostosowa�)
    }

    // Obs�uga zdarzenia �mierci przeciwnika
    void HandleEnemyDeath()
    {
        // Dodaj jeden punkt zdrowia po �mierci przeciwnika
        currentHealth++;
        Debug.Log("Player gained 1 health. Current health: " + currentHealth);
        healthString = currentHealth + " / 5";
    }
    static async Task WaitForHalfSecond()
    {
        // Poczekaj na p� sekundy
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}
