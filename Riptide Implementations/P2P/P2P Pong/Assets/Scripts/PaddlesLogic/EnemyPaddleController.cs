using UnityEngine;
using Zenject;

namespace PaddlesLogic
{
    public class EnemyPaddleController : MonoBehaviour
    {
        [SerializeField] private float directionChangeInterval = 1.5f;
        private float _elapsedTime;
        private float _direction = 1f;
        private Paddle _paddle;
        
        [Inject]
        private void Init([Inject(Id = PaddleType.Enemy)]Paddle paddle)
        {
            _paddle = paddle;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (!(_elapsedTime >= directionChangeInterval)) return;
            _direction *= -1f;
            _elapsedTime = 0f;
            _paddle.SetDirection(_direction);
        }
    }
}