using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Vector2 _inputValueLook;
    [SerializeField] private float _lookIntencity = 0.01f;
    [SerializeField] private float _inputValueShot;
    [SerializeField] private float _inputHoldValueShot;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shotSE;

    private Vector3 _angles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInput.actions["Look"].Enable();
        _playerInput.actions["Look"].performed += OnLookActionPerformed;
        _playerInput.actions["Look"].canceled += OnLookActionCanceled;

        _playerInput.actions["Shot"].Enable();
        _playerInput.actions["Shot"].performed += OnShotActionPerformed;
        _playerInput.actions["Shot"].canceled += OnShotActionCanceled;

        SetCursorActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_inputValueShot != _inputHoldValueShot && _inputValueShot >= 1) 
        {
            SetCursorActive(false);
            Shot();
        }
        _inputHoldValueShot = _inputValueShot;

        if(Input.GetKeyDown(KeyCode.Escape)) SetCursorActive(true);

        Rotate();
    }

    private void OnLookActionPerformed(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        _inputValueLook = value;
    }

    private void OnLookActionCanceled(InputAction.CallbackContext context)
    {
        _inputValueLook = Vector2.zero;
    }

    private void OnShotActionPerformed(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        _inputValueShot = value;
    }

    private void OnShotActionCanceled(InputAction.CallbackContext context)
    {
        _inputValueShot = 0;
    }

    public void Rotate()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        _angles += new Vector3(-_inputValueLook.y * _lookIntencity, _inputValueLook.x * _lookIntencity, 0);
        _angles.x = Mathf.Clamp(_angles.x, -45, 45);
        _angles.y = Mathf.Clamp(_angles.y, -30, 30);
        transform.eulerAngles = _angles;
    }

    public void Shot()
    {
        Bullet clone = Instantiate(_bulletPrefab, _shotPoint.position, _shotPoint.rotation);
        Destroy(clone.gameObject, 5.0f);

        Rigidbody rb = clone.GetComponent<Rigidbody>();
        rb?.AddForce(_shotPoint.forward * 10, ForceMode.Impulse);

        PlaySE(_shotSE);
    }

    public void SetCursorActive(bool active)
    {
        if(active == true) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = active;
    }

    public void PlaySE(AudioClip clip)
    {
        _audioSource?.PlayOneShot(clip);
    }
}
