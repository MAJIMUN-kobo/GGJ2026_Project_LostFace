using Live2D.Cubism.Core;
using UnityEngine;

public class LiveCharacter : MonoBehaviour
{
    [SerializeField] private CubismModel _model;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        _model.Parameters[0].Value = Mathf.Sin(Time.time) * 15;
    }
}
