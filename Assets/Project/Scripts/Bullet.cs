using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _previousPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HitComplementRay(LayerMask.GetMask("Mask"));
    }

    private void LateUpdate()
    {
        _previousPosition = transform.position;
    }

    private void HitComplementRay(LayerMask layer)
    {
        var startRayPoint = transform.position;
        var direction = (_previousPosition - startRayPoint).normalized;
        var distance = Vector3.Distance(_previousPosition, startRayPoint);

        Debug.DrawRay(startRayPoint, direction * distance, Color.red);

        Ray ray = new Ray(startRayPoint, direction);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance, layer))
        {
            transform.position = hit.point;
        }
    }
}
