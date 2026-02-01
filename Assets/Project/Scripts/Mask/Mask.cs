using UnityEngine;
using UnityEngine.SceneManagement;

public class Mask : BaseMask
{
    public override void OnFall()
    {
        LiveCharacter character = GameObject.FindAnyObjectByType<LiveCharacter>();
        character?.NotifyEmotion(emotionParameter.joy, emotionParameter.anger, emotionParameter.sorrow, emotionParameter.pleasure);

        ScoreElementUGUI scoreElementUI = GameObject.FindAnyObjectByType<ScoreElementUGUI>();
        scoreElementUI?.CreateMaskScore(transform.position, transform.eulerAngles, addScoreValue);
        
        GameManager.Instance.AddScore(addScoreValue);

        isFalled = true;

        PlaySE(_fallSE);
        Destroy(gameObject, 1.0f);

        if(_deathFlag) SceneManager.LoadScene("GameOverScene");

        base.OnFall();
    }
}
