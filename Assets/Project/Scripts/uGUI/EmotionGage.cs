using UnityEngine;
using UnityEngine.UI;

public class EmotionGage : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private Color _fillColor = Color.white;

    void Start()
    {
        SetColor(_fillColor);
        SetFillAmount(0, 10);
        
    }

    /// <summary>
    /// ÉtÉBÉãÇÃê›íË
    /// </summary>
    /// <param name="current"></param>
    /// <param name="max"></param>
    public void SetFillAmount(float current, float max)
    {
        _fillImage.fillAmount = current / max;
    }

    /// <summary>
    /// êFÇÃê›íË
    /// </summary>
    /// <param name="color"></param>
    public void SetColor(Color color)
    {
        _fillColor = color;
        _fillImage.color = color;
    }
}
