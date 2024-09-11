using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class BallThrower : MonoBehaviour
{
    public struct BallThrowerParameters
    {
        public float StartVelocity;
        public Rigidbody2D BallRigidbody;
    }
    
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float maxAngleDeviation;
    
    private float _startVelocity;
    private Rigidbody2D _ballRigidbody;

    [Inject]
    private void Init(BallThrowerParameters parameter)
    {
        _startVelocity = parameter.StartVelocity;
        _ballRigidbody = parameter.BallRigidbody;
    }

    private void Start()
    {
        ThrowBall();
    }

    public void ThrowBall()
    {
        _ballRigidbody.position = startPosition;
        var angle = GetRandomAngle();
        var direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        _ballRigidbody.velocity = direction * _startVelocity;
    }

    private float GetRandomAngle()
    {
        var isRight = Random.Range(0, 2) == 0;
        if (isRight)
        {
            return Random.Range(-maxAngleDeviation, maxAngleDeviation);
        }
        return Random.Range(180-maxAngleDeviation, 180+maxAngleDeviation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var startPosition = new Vector3(this.startPosition.x, this.startPosition.y, 0);
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos(maxAngleDeviation * Mathf.Deg2Rad), Mathf.Sin(maxAngleDeviation * Mathf.Deg2Rad), 0));
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos((180 - maxAngleDeviation) * Mathf.Deg2Rad), Mathf.Sin((180 - maxAngleDeviation) * Mathf.Deg2Rad), 0));
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos((180 + maxAngleDeviation) * Mathf.Deg2Rad), Mathf.Sin((180 + maxAngleDeviation) * Mathf.Deg2Rad), 0));
        Gizmos.DrawLine(startPosition, startPosition + new Vector3(Mathf.Cos(- maxAngleDeviation * Mathf.Deg2Rad), Mathf.Sin(- maxAngleDeviation * Mathf.Deg2Rad), 0));
    }
}
