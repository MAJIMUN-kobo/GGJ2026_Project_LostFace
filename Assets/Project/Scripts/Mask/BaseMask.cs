using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BaseMask : MonoBehaviour
{
    [System.Serializable]
    public class EmotionParameter
    {
        public float joy;           // äÏ
        public float anger;         // ì{
        public float sorrow;        // à£
        public float pleasure;      // äy
    }

    [Header("** Emotion Settings **")]
    public EmotionParameter emotionParameter;

    [Header("** Score Settings **")]
    public int addScoreValue = 100;

    [Header("** Debug Info **")]
    [SerializeField] protected bool _fallCheck;
    [SerializeField] public bool _deathFlag;

    [Header("** Audio Settings **")]
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _fallSE;

    public bool isFalled { get; protected set; } = false;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag.Contains("FallCheck") && !isFalled)
        {
            OnFall();
            Debug.Log("Falled");
        }
    }

    /// <summary>
    /// óéâ∫èàóù
    /// </summary>
    public virtual void OnFall()
    {

    }


    protected void DebugReset()
    {
        isFalled = false;
        transform.position = new Vector3(0,0,3);
        transform.rotation = Quaternion.identity;
        transform.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    protected void PlaySE(AudioClip clip)
    {
        _audioSource?.PlayOneShot(clip);
    }
}
