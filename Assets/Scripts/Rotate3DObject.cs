using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class Rotate3DObject : MonoBehaviour
{
    #region Input Actions
    [SerializeField]
    private InputActionAsset _actions;

    public InputActionAsset actions
    {
        get => _actions;
        set => _actions = value;
    }

    protected InputAction leftClickPressedInputAction { get; set; }

    protected InputAction mouseLookInputAction { get; set; }

    #endregion

    #region Variables

    private bool _rotateAllowed;

    private Camera _camera;

    [SerializeField] private float _speed;

    [SerializeField] private bool _inverted;

    public LayerMask selectableLayers;
    private bool isSelecting = false;
    [SerializeField] private Animator animator;

    private Quaternion _initialRotation; // �洢��ʼ��ת״̬
    private bool _isReturning; // �Ƿ����ڻָ�״̬
    [SerializeField] private float _returnSpeed = 2f; // �ָ��ٶ�

    #endregion

    private void Awake()
    {
        InitializeInputSystem();
        _initialRotation = transform.rotation;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _camera = Camera.main;
    }

    private void InitializeInputSystem()
    {
        leftClickPressedInputAction = actions.FindAction("Left Click");
        if (leftClickPressedInputAction != null)
        {
            leftClickPressedInputAction.started += OnLeftClickPressed;
            leftClickPressedInputAction.performed += OnLeftClickPressed;
            leftClickPressedInputAction.canceled += OnLeftClickPressed;
        }

        mouseLookInputAction = actions.FindAction("Mouse Look");

        actions.Enable();
    }

    protected virtual void OnLeftClickPressed(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            _rotateAllowed = true;

        }
        else if (context.canceled)
        {
            _rotateAllowed = false;
            Ray();
            _isReturning = true;
        }

        else if (context.started)
        {
            Ray();
            _isReturning = false;
        }


    }

    private void Ray()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayers))
        {
            GameObject selectedObject = hit.collider.gameObject;
            isSelecting = !isSelecting;

            //  ������ִ��ѡ����������������ʾ
            SelectObject(selectedObject);
        }
    }

    protected virtual Vector2 GetMouseLookInput()
    {
        if (mouseLookInputAction != null)
            return mouseLookInputAction.ReadValue<Vector2>();

        return Vector2.zero;
    }

    private void Update()
    {
        if (_rotateAllowed&&isSelecting)
        {
            HandleRotation();
        }
        else if (_isReturning)
        {
            ReturnToInitialRotation();
        }
        /*if (!_rotateAllowed)
            return;

        Vector2 MouseDelta = GetMouseLookInput();

        MouseDelta *= _speed * Time.deltaTime;

        transform.Rotate(Vector3.up * (_inverted ? 1 : -1), MouseDelta.x, Space.World);
        transform.Rotate(Vector3.right * (_inverted ? -1 : 1), MouseDelta.y, Space.World);
        */
    }
    void SelectObject(GameObject obj)
    {
        if (isSelecting)
        {
            animator.SetTrigger("open");
            Debug.Log(1);
        }
        else
        {
            animator.SetTrigger("close");
            Debug.Log(2);
        }
    }
    private void HandleRotation()
    {
        Vector2 mouseDelta = GetMouseLookInput();
        mouseDelta *= _speed * Time.deltaTime;

        // ˮƽ��ת��������Y�ᣩ
        transform.Rotate(
            Vector3.up * (_inverted ? 1 : -1),
            mouseDelta.x,
            Space.World
        );

        // ��ֱ��ת���Ʊ���X�ᣩ
        transform.Rotate(
            Vector3.right * (_inverted ? -1 : 1),
            mouseDelta.y,
            Space.World
        );
    }

    private void ReturnToInitialRotation()
    {
        // ʹ�����β�ֵƽ������
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            _initialRotation,
            _returnSpeed * Time.deltaTime
        );

        // ����Ƿ�ӽ���ʼ��ת
        if (Quaternion.Angle(transform.rotation, _initialRotation) < 0.1f)
        {
            transform.rotation = _initialRotation;
            _isReturning = false;
        }
    }

}
