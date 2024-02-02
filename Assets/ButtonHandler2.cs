using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class ButtonHandler : MonoBehaviour
{
    public void OnButtonClick()
    {
        UIManager.Instance.HideItemPopup();
        ScrollScript.Instance.Stop_letter();
    }
}