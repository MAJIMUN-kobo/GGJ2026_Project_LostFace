using Live2D.Cubism.Core;
using UnityEngine;

public class LiveCharacter : MonoBehaviour
{
    [System.Serializable]
    public class EmotionParameter
    {
        public float joy;           // Šì
        public float anger;         // “{
        public float sorrow;        // ˆ£
        public float pleasure;      // Šy
    }

    public EmotionParameter emotionParameter;
    
    [SerializeField] private CubismModel _model;
    [SerializeField] private EmotionElementUGUI _emotionUI;

    void Start()
    {
        _emotionUI = GameObject.FindAnyObjectByType<EmotionElementUGUI>();
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        _model.Parameters[0].Value += Input.GetAxis("Mouse X");
        _model.Parameters[0].Value = Mathf.Clamp(_model.Parameters[0].Value, -10, 10);
    }

    public void NotifyEmotion(float joy, float anger, float sorrow, float pleasure)
    {
        emotionParameter.joy += joy;
        emotionParameter.anger += anger;
        emotionParameter.sorrow += sorrow;
        emotionParameter.pleasure += pleasure;

        _emotionUI.SetEmotionValue(0, emotionParameter.joy, 10);
        _emotionUI.SetEmotionValue(1, emotionParameter.anger, 10);
        _emotionUI.SetEmotionValue(2, emotionParameter.sorrow, 10);
        _emotionUI.SetEmotionValue(3, emotionParameter.pleasure, 10);

    }
}
