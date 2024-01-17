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

        // Rejestrujemy funkcjê HandleEnemyDeath do obs³ugi zdarzenia OnEnemyDeath
        EnemyHealth.OnEnemyDeath += HandleEnemyDeath;

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = damageSound;
    }

    void Update()
    {
        // Aktualizuj czas niewra¿liwoœci gracza
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
                TakeDamage(1); // Mo¿esz dostosowaæ wartoœæ obra¿eñ
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

        // Dodaj dowolne dodatkowe logiki zwi¹zane z otrzymywaniem obra¿eñ, np. animacje, efekty dŸwiêkowe itp.

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    static async Task Die()
    {
        // Dodaj dowolne dodatkowe logiki zwi¹zane ze œmierci¹ gracza, np. restart gry, wyœwietlenie ekranu œmierci itp.
        Debug.Log("czekanie rozpoczête");
        await WaitForHalfSecond();
        if (currentHealth <= 0)
        {
            Debug.Log("Player died");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        Debug.Log("czekanie zakoñczone");
    }

    void Knockback(Vector3 enemyPosition)
    {
        // Ustawiamy wartoœæ y wektora kierunkowego na 1, aby wskazywa³ w kierunku górnym
        Vector2 knockbackDirection = new Vector2(0f, 1f);

        // Resetuj prêdkoœæ pionow¹ gracza, aby unikn¹æ wp³ywu grawitacji na odbicie
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);

        // Dodaj si³ê odrzutu do gracza w kierunku górnym
        playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    void MakeInvincible()
    {
        isInvincible = true;
        invincible = invincibleDuration; // Ustaw czas niewra¿liwoœci na 0.5 sekundy (mo¿esz dostosowaæ)
    }

    // Obs³uga zdarzenia œmierci przeciwnika
    void HandleEnemyDeath()
    {
        // Dodaj jeden punkt zdrowia po œmierci przeciwnika
        currentHealth++;
        Debug.Log("Player gained 1 health. Current health: " + currentHealth);
        healthString = currentHealth + " / 5";
    }
    static async Task WaitForHalfSecond()
    {
        // Poczekaj na pó³ sekundy
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}
