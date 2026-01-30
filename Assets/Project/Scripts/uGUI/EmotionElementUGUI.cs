using UnityEngine;

public class EmotionElementUGUI : MonoBehaviour
{
    public EmotionGage[] emotionGages;

    public void SetEmotionValue(int index, float currentValue, float maxValue)
    {
        emotionGages[index].SetFillAmount(currentValue, maxValue);
    }
}
