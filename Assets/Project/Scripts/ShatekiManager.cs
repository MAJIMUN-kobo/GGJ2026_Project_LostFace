using Live2D.Cubism.Core.Unmanaged;
using Unity.VisualScripting;
using UnityEngine;

public class ShatekiManager : MonoBehaviour
{
    [SerializeField] private BaseMask[] _maskPrefabs;
    [SerializeField] private Transform _generatePoint;
    [SerializeField] private Transform[] _maskPoints;

    void Start()
    {
        _maskPoints = GetPointAll();
        SetStageAll();
    }

    void Update()
    {
        if(AllHitCheck())
        {
            SetStageAll();
        }
    }

    public void SetStageAll()
    {
        for(int i = 0; i < _maskPoints.Length; i++)
        {
            var maskPrefab = DiceMask();
            InstantiateMask(maskPrefab, _maskPoints[i]);
        }
    }

    private BaseMask DiceMask()
    {
        int index = Random.Range(0, _maskPrefabs.Length);
        return _maskPrefabs[index];
    }

    private BaseMask InstantiateMask(BaseMask origin, Transform point)
    {
        var clone = Instantiate(origin, point);
        clone.transform.localPosition = Vector3.zero;

        return clone;
    }

    private Transform[] GetPointAll()
    {
        Debug.Log(_generatePoint);
        var children = _generatePoint.GetComponentsInChildren<Transform>();
        var points = new Transform[children.Length - 1];
        for(int i = 1; i < children.Length; i++)
        {
            points[i - 1] = children[i];
        }

        return points;
    }

    private bool AllHitCheck()
    {
        var masks = GameObject.FindObjectsByType<BaseMask>(FindObjectsSortMode.None);
        if(masks.Length == 0) return true;
        else return false;
    }
}
