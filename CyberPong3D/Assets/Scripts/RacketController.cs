using UnityEngine;

public class RacketController : MonoBehaviour
{

    #region Variables

    [SerializeField] private float _speed;

    [SerializeField] private KeyCode _up;
    [SerializeField] private KeyCode _down;
    private bool _moveUp;
    private bool _moveDown;

    [SerializeField] private Rigidbody _rigidbody;

    #endregion


    #region Unity Functions

    private void Update()
    {
        _moveUp = Input.GetKey(this._up);
        _moveDown = Input.GetKey(this._down);
    }

    private void FixedUpdate()
    {
        if (_moveUp)
        {
            _rigidbody.velocity = _speed * Time.fixedDeltaTime * Vector3.forward;
        }
        else if (_moveDown)
        {
            _rigidbody.velocity = _speed * Time.fixedDeltaTime * Vector3.back;
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    #endregion

    #region Functions
    #endregion
}