using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shotPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCursorActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        { 
            SetCursorActive(false);
            Shot();
        }
        if(Input.GetKeyDown(KeyCode.Escape)) SetCursorActive(true);

        Rotate();
    }

    public void Rotate()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(-mouseY, mouseX, 0);
    }

    public void Shot()
    {
        Bullet clone = Instantiate(_bulletPrefab, _shotPoint.position, _shotPoint.rotation);
        Destroy(clone.gameObject, 5.0f);

        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb?.AddForce(_shotPoint.forward * 10, ForceMode.Impulse);
    }

    public void SetCursorActive(bool active)
    {
        if(active == true) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = active;
    }
}
