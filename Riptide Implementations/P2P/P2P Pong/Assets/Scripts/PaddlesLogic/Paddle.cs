using UnityEngine;
using Zenject;

namespace PaddlesLogic
{
    public class Paddle : MonoBehaviour
    {
        public struct PaddleParameters
        {
            public float MaxY;
            public float MinY;
            public float Speed;
        }
    
        private float _maxY;
        private float _minY;
        private float _speed;
        private float _direction;

        [Inject]
        private void Init(PaddleParameters parameters)
        {
            _maxY = parameters.MaxY;
            _minY = parameters.MinY;
            _speed = parameters.Speed;
        }
    
        public void SetDirection(float direction)
        {
            _direction = direction;
        }
    
        private void Update()
        {
            var currentPosition = transform.position;
            var newPosition = currentPosition + Vector3.up * _direction * _speed * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, _minY, _maxY);
            transform.position = newPosition;
        }
    }
}
