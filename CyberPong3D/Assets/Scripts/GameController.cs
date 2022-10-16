using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Variables

    // UI Text elements
    [SerializeField] private TextMeshProUGUI _leftScoreText;
    [SerializeField] private TextMeshProUGUI _rightScoreText;

    // Keeping the scores
    private int _scoreLeft = 0;
    private int _scoreRight = 0;

    #endregion

    #region Unity Functions

    #endregion

    #region Custom Functions
    
    public void RightScored()
    {
        Debug.Log("Right Scored!!!1");
        _scoreRight++;
        UpdateUI();
    }

    public void LeftScored()
    {
        Debug.Log("Left Scored!!!");
        _scoreLeft++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _leftScoreText.text = _scoreLeft.ToString();
        _rightScoreText.text = _scoreRight.ToString();
    }

    #endregion
}
