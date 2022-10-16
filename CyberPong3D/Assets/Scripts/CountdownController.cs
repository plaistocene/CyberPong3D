using UnityEngine;
using UnityEngine.Events;

public class CountdownController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Animator _countdownTimerAnimator;

    public UnityEvent countdownTimerEndedUnityEvent;
    
    #endregion

    #region Unity Functions
    
    #endregion

    #region Custom Functions
    
    public void StartCountdownTimer()
    {
        _countdownTimerAnimator.SetTrigger("StartCountdown");
    }

    public void CountdownTimerEnded()
    {
        countdownTimerEndedUnityEvent.Invoke();
    }

    #endregion
}
