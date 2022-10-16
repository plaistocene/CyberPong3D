using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    #region Variables

    // Ball rigidbody
    [SerializeField] private Rigidbody _rigidbody;

    // Ball speed
    [SerializeField] private float _speed;

    // Direction to Go
    private Vector3 _direction;

    // Minimum angle that ball can go
    [SerializeField] private float minDirection = 0.3f;


    // is Ball moving
    private bool _shouldBallMove = false;

    // default location for ball
    private Vector3 _defaultBallPosition;

    // for vfx spark
    [SerializeField] private GameObject _sparkVFXGO;

    #endregion

    #region Unity Functions

    private void Start()
    {
        _defaultBallPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!_shouldBallMove) return;

        _rigidbody.MovePosition(_rigidbody.position + _speed * Time.fixedDeltaTime * _direction);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("Wall"))
        {
            _direction.z = -_direction.z;
            hit = true;
        }

        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (transform.position - other.transform.position).normalized;

            var xValue = newDirection.x;
            var zValue = newDirection.z;

            newDirection.x = Mathf.Sign(xValue) * Mathf.Max(Mathf.Abs(xValue), minDirection);
            newDirection.z = Mathf.Sign(zValue) * Mathf.Max(Mathf.Abs(zValue), minDirection);

            _direction = newDirection;

            hit = true;
        }

        if (hit)
        {
            GameObject sparkGO = Instantiate(_sparkVFXGO, transform.position, transform.rotation);
            Destroy(sparkGO, 2f);
        }
    }

    #endregion

    #region Custom Functions

    public void StopBallMovement()
    {
        _shouldBallMove = false;
    }

    public void StartBallMovement()
    {
        ChooseBallDirection();
        _shouldBallMove = true;
    }

    private void ChooseBallDirection()
    {
        float randomDirectionX = Random.Range(-1f, 1f);
        float randomDirectionZ = Random.Range(-1f, 1f);

        _direction = new Vector3(randomDirectionX, 0, randomDirectionZ);
    }

    public void ResetBall()
    {
        StopBallMovement();
        transform.position = _defaultBallPosition;
    }

    #endregion
}
