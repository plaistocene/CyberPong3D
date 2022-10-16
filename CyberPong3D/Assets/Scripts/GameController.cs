using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _scoreLeft = 0;
    [SerializeField] private int _scoreRight = 0;
    
    #endregion

    #region Unity Functions
    
    private void Start()
    {
        
    }

    private void Update()
    {
                
    }
    
    #endregion

    #region Custom Functions
    
    public void RightScored()
    {
        Debug.Log("Right Scored!!!1");
        _scoreRight++;
    }

    public void LeftScored()
    {
        Debug.Log("Left Scored!!!");
        _scoreLeft++;
    }
    
    #endregion
}
