using TMPro;
using UnityEngine;

public class MaskScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreValueText;
    [SerializeField] private string _unitText = "pt";

    public void SetScoreValue(int score)
    {
        if (_scoreValueText == null) return;
        _scoreValueText.text = score.ToString() + _unitText;
    }
}
