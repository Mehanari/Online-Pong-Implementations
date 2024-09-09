using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float startForce = 10f;

    private void Start()
    {
        GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(Random.value, Random.value) * startForce, ForceMode2D.Impulse);
    }
}
