using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreElementUGUI : MonoBehaviour
{
    [SerializeField] private MaskScoreView _maskScoreViewPrefab;
    [SerializeField] private GameScoreView _scoreView;


    public void CreateMaskScore(Vector3 setPosition, Vector3 setAngle, int score)
    {
        var screenPoint = Camera.main.WorldToScreenPoint(setPosition);

        var clone = Instantiate(_maskScoreViewPrefab, transform);
        var rect = clone.transform.GetComponent<RectTransform>();
        rect.position = screenPoint;

        clone.SetScoreValue(score);

        Destroy(clone.gameObject, 1f);
    }

    public void SetScoreText(string score)
    {
        _scoreView?.SetScoreText(score);
    }
}
