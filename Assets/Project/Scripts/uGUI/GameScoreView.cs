using TMPro;
using UnityEngine;

public class GameScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreViewText;

    public void SetScoreText(string score)
    {
        _scoreViewText.text = score;
    }
}
