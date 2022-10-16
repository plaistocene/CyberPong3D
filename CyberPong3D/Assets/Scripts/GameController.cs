using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    #region Variables

    // UI Text elements
    [SerializeField] private TextMeshProUGUI _leftScoreText;
    [SerializeField] private TextMeshProUGUI _rightScoreText;

    // Keeping the scores
    private int _scoreLeft = 0;
    private int _scoreRight = 0;

    // Managing the game start
    private bool _isStarted = false;

    // The event to wake the ball
    public UnityEvent startGameUnityEvent;

    // The event to reset the game after score
    public UnityEvent resetAfterScoreUnityEvent;

    #endregion

    #region Unity Functions

    private void Update()
    {
        if (_isStarted) return;

        if (Input.GetKey(KeyCode.Space))
        {
            _isStarted = true;
            startGameUnityEvent.Invoke();
        }
    }

    #endregion

    #region Custom Functions

    public void RightScored()
    {
        _scoreRight++;
        UpdateUI();
        ResetAfterScore();
    }

    public void LeftScored()
    {
        _scoreLeft++;
        UpdateUI();
        ResetAfterScore();
    }

    private void UpdateUI()
    {
        _leftScoreText.text = _scoreLeft.ToString();
        _rightScoreText.text = _scoreRight.ToString();
    }

    private void ResetAfterScore()
    {
        resetAfterScoreUnityEvent.Invoke();
    }

    #endregion
}
