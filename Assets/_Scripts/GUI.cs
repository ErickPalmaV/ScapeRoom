using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField] RectTransform CollectionableContainer;
    [SerializeField] RectTransform WinContainer;
    [SerializeField] TextMeshProUGUI CollectionableText;
    [SerializeField] TextMeshProUGUI WinLoseText;

    public void ShowCollectionable()
    {
        CollectionableContainer.gameObject.SetActive(true);
    }
    public void HideCollectionable()
    {
        CollectionableContainer.gameObject.SetActive(false);
    }

    public void UpdateCollectionable(int value)
    {
        CollectionableText.text = value.ToString();
    }

    public void Win()
    {
        HideCollectionable();
        ShowWin();
    }

    public void ShowWin()
    {
        WinContainer.gameObject.SetActive(true);
        WinLoseText.text = "You win!!";
    }

    public void ShowLose()
    {
        WinContainer.gameObject.SetActive(true);
        WinLoseText.text = "You lose!!";
    }
    public void HideWinLose()
    {
        WinContainer.gameObject.SetActive(false);
    }

    public void Lose()
    {
        HideCollectionable();
        ShowLose();
    }
}
