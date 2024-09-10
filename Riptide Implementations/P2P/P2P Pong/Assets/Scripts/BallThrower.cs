using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class BallThrower : MonoBehaviour
{
    public struct BallThrowerParameters
    {
        public float StartVelocity;
        public Vector2 StartPosition;
        public Rigidbody2D BallRigidbody;
        public float MaxAngleDeviation;
    }
    
    private float _startVelocity;
    private Vector2 _startPosition;
    private Rigidbody2D _ballRigidbody;
    private float _maxAngleDeviation;

    [Inject]
    private void Init(BallThrowerParameters parameter)
    {
        _startVelocity = parameter.StartVelocity;
        _startPosition = parameter.StartPosition;
        _ballRigidbody = parameter.BallRigidbody;
        _maxAngleDeviation = parameter.MaxAngleDeviation;
    }

    private void Start()
    {
        ThrowBall();
    }

    public void ThrowBall()
    {
        _ballRigidbody.position = _startPosition;
        var angle = GetRandomAngle();
        var direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        _ballRigidbody.velocity = direction * _startVelocity;
    }

    private float GetRandomAngle()
    {
        var isRight = Random.Range(0, 2) == 0;
        if (isRight)
        {
            return Random.Range(-_maxAngleDeviation, _maxAngleDeviation);
        }
        return Random.Range(180-_maxAngleDeviation, 180+_maxAngleDeviation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var startPosition = new Vector3(_startPosition.x, _startPosition.y, 0);
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos(_maxAngleDeviation * Mathf.Deg2Rad), Mathf.Sin(_maxAngleDeviation * Mathf.Deg2Rad), 0));
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos((180 - _maxAngleDeviation) * Mathf.Deg2Rad), Mathf.Sin((180 - _maxAngleDeviation) * Mathf.Deg2Rad), 0));
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos((180 + _maxAngleDeviation) * Mathf.Deg2Rad), Mathf.Sin((180 + _maxAngleDeviation) * Mathf.Deg2Rad), 0));
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos(- _maxAngleDeviation * Mathf.Deg2Rad), Mathf.Sin(- _maxAngleDeviation * Mathf.Deg2Rad), 0));
    }
}
