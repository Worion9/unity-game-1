using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject itemPopupPanel;
    public TextMeshProUGUI itemPopupText;

    public Rigidbody2D innyObiektRigidbody;
    public TimerScript timerScriptReference;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowItemPopup(string itemText)
    {
        itemPopupText.text = itemText;
        itemPopupPanel.SetActive(true);
        innyObiektRigidbody.bodyType = RigidbodyType2D.Static;
        timerScriptReference.ZatrzymajWznowCzas();
        // Opcjonalnie, mo¿esz dodaæ opóŸnienie lub przycisk do zamykania okienka.
    }

    public void HideItemPopup()
    {
        itemPopupPanel.SetActive(false);
        innyObiektRigidbody.bodyType = RigidbodyType2D.Dynamic;
        timerScriptReference.ZatrzymajWznowCzas();
    }
}