using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace PaddlesLogic
{
    public class PlayerPaddleController : MonoBehaviour
    {
        private Controls _controls;
        private Paddle _paddle;
        private Vector2 _currentTouchPosition;

        [Inject]
        private void Init([Inject(Id = PaddleType.Player)]Paddle paddle)
        {
            _paddle = paddle;
        }

        private void Awake()
        {
            _controls = new Controls();
        }
    
        private void OnEnable()
        {
            _controls.Enable();
            _controls.Gameplay.Direction.performed += OnDirectionPerformed;
            _controls.Gameplay.Direction.canceled += OnDirectionCanceled;
            _controls.Gameplay.TouchPosition.performed += OnTouchPosition;
            _controls.Gameplay.Touch.performed += OnTouchPerformed;
            _controls.Gameplay.Touch.canceled += OnTouchCanceled;
        }

        private void OnDisable()
        {
            _controls.Disable();
            _controls.Gameplay.Direction.performed -= OnDirectionPerformed;
            _controls.Gameplay.Direction.canceled -= OnDirectionCanceled;
            _controls.Gameplay.TouchPosition.performed -= OnTouchPosition;
            _controls.Gameplay.Touch.performed -= OnTouchPerformed;
            _controls.Gameplay.Touch.canceled -= OnTouchCanceled;
        }
    
        private void OnDirectionPerformed(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<float>();
            _paddle.SetDirection(direction);
        }
    
        private void OnDirectionCanceled(InputAction.CallbackContext context)
        {
            _paddle.SetDirection(0f);
        }
    
        private void OnTouchPosition(InputAction.CallbackContext context)
        {
            _currentTouchPosition = context.ReadValue<Vector2>();
        }
    
        private void OnTouchPerformed(InputAction.CallbackContext obj)
        {
            var touchPositionY = _currentTouchPosition.y;
            var screenWidth = Screen.height;
            if (touchPositionY > screenWidth / 2)
            {
                _paddle.SetDirection(1f);
            }
            else
            {
                _paddle.SetDirection(-1f);
            }
        }
    
        private void OnTouchCanceled(InputAction.CallbackContext obj)
        {
            _paddle.SetDirection(0f);
        }
    }
}
