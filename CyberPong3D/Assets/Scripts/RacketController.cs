using UnityEngine;

public class RacketController : MonoBehaviour
{

    #region Variables

    // References
    [SerializeField] private Rigidbody _racketRigidbody;
    [SerializeField] private Transform _ballTransform;

    // Gameplay Variables
    [SerializeField] private float _playerSpeed;

    [SerializeField] private float _aiSpeed = 300f;
    [SerializeField] private float _offset = 0.2f;

    // Gameplay Control Variables
    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    private bool _moveUp;
    private bool _moveDown;

    // vs. ai or vs. player controller
    [SerializeField] private bool _isPlayer = true;

    #endregion


    #region Unity Functions

    private void Update()
    {
        if (_isPlayer)
        {
            _moveUp = Input.GetKey(this._up);
            _moveDown = Input.GetKey(this._down);
        }
    }

    private void FixedUpdate()
    {
        if (_isPlayer)
        {
            MoveByPlayer();
        }
        else
        {
            MoveByComputer();
        }
    }

    #endregion

    #region Functions

    private void MoveByPlayer()
    {
        if (_moveUp)
        {
            _racketRigidbody.velocity = _playerSpeed * Time.fixedDeltaTime * Vector3.forward;
        }
        else if (_moveDown)
        {
            _racketRigidbody.velocity = _playerSpeed * Time.fixedDeltaTime * Vector3.back;
        }
        else
        {
            _racketRigidbody.velocity = Vector3.zero;
        }
    }

    private void MoveByComputer()
    {
        if (_ballTransform.position.z > transform.position.z + _offset)
        {
            _racketRigidbody.velocity = _aiSpeed * Time.fixedDeltaTime * Vector3.forward;
        }
        else if (_ballTransform.position.z < transform.position.z - _offset)
        {
            _racketRigidbody.velocity = _playerSpeed * Time.fixedDeltaTime * Vector3.back;
        }
        else
        {
            _racketRigidbody.velocity = Vector3.zero;
        }
    }

    #endregion
}