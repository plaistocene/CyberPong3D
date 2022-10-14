using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speed;

    private Vector3 _direction;

    [SerializeField] private float minDirection = 0.2f;

    #endregion

    #region Unity Functions

    private void Start()
    {
        float randomDirectionX = Random.Range(-1f, 1f);
        float randomDirectionZ = Random.Range(-1f, 1f);

        _direction = new Vector3(randomDirectionX, 0, randomDirectionZ);
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _speed * Time.fixedDeltaTime * _direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            _direction.z = -_direction.z;
        }

        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            var xValue = newDirection.x;
            var zValue = newDirection.z;

            newDirection.x = Mathf.Sign(xValue) * Mathf.Max(Mathf.Abs(xValue), minDirection);
            newDirection.z = Mathf.Sign(zValue) * Mathf.Max(Mathf.Abs(zValue), minDirection);

            _direction = newDirection;
        }
    }

    #endregion

    #region Custom Functions

    #endregion
}
