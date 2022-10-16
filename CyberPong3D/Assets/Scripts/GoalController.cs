using UnityEngine;
using UnityEngine.Events;

public class GoalController : MonoBehaviour
{
    #region Variables

    public UnityEvent onTriggerEnter;

    #endregion

    #region Unity Functions

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            onTriggerEnter.Invoke();
        }
    }

    #endregion

    #region Custom Functions



    #endregion
}
