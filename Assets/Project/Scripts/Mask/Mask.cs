using UnityEngine;

public class Mask : BaseMask
{
    public override void OnFall()
    {
        LiveCharacter character = GameObject.FindAnyObjectByType<LiveCharacter>();
        character?.NotifyEmotion(emotionParameter.joy, emotionParameter.anger, emotionParameter.sorrow, emotionParameter.pleasure);

        isFalled = true;

        PlaySE(_fallSE);
        Destroy(gameObject, 1.0f);

        base.OnFall();
    }
}
