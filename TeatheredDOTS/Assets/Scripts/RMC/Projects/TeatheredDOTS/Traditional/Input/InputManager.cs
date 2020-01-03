using RMC.Input;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private CharacterInputAction _characterInputAction = null;

    private Vector2 _move = new Vector2();
    public Vector2 Move { get => _move; private set => _move = value; }

    private bool _isPause = false;
    public bool IsPause { get => _isPause; private set => _isPause = value; }
    
    protected override void Awake()
    {
        base.Awake();
        _characterInputAction = new CharacterInputAction();
    }
    
    protected void OnEnable()
    {
        if (_characterInputAction != null)
        {
            _characterInputAction.Enable();
        }
    }

    protected void OnDisable()
    {
        if (_characterInputAction != null)
        {
            _characterInputAction.Disable();
        }
    }

    protected void Start()
    {
        _characterInputAction.Player.Move.started += OnMove;
        _characterInputAction.Player.Move.performed += OnMove;
        _characterInputAction.Player.Move.canceled += OnMove;
        //
        _characterInputAction.Player.Pause.performed += OnPause;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
        //Debug.Log("OnMove!" + Move);
    }
    
    public void OnPause (InputAction.CallbackContext context)
    {
        // If it's okay to accept a GC hit, you can also read out values as objects.
        // In this case, you don't have to know the value type.
        //Debug.Log("Value: " + context.ReadValueAsObject());
        
        bool isKeyDown = Mathf.Approximately(context.ReadValue<float>(), 1);
        if (isKeyDown)
        {
            IsPause = !IsPause;
        }
    }
}
