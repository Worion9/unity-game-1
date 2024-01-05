using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // SprawdŸ, czy obiekt, który dotkn¹³ jest graczem (mo¿esz dostosowaæ tag, nazwê warstwy itp.)
        if (collision.collider.CompareTag("Player"))
        {
            // Restartuj scenê
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Pobierz indeks aktualnej sceny
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Za³aduj ponownie aktualn¹ scenê
        SceneManager.LoadScene(currentSceneIndex);
    }
}
