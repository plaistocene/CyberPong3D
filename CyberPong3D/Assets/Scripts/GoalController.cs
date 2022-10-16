using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    #region Variables

    public UnityEvent onTriggerEnterUnityEvent;

    #endregion

    #region Unity Functions

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            onTriggerEnterUnityEvent.Invoke();
        }
    }

    #endregion

    #region Custom Functions



    #endregion
}
