using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawd�, czy obiekt, kt�ry dotkn�� jest graczem (mo�esz dostosowa� tag, nazw� warstwy itp.)
        if (collision.collider.CompareTag("Player"))
        {
            // Restartuj scen�
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Pobierz indeks aktualnej sceny
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Za�aduj ponownie aktualn� scen�
        SceneManager.LoadScene(currentSceneIndex);
    }
}
