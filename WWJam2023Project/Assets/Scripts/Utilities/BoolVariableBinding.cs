using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoolVariableBinding : MonoBehaviour
{
    public BoolVariable _observedVariable;
    public UnityEvent OnTrueResponse;
    public UnityEvent OnFalseResponse;

    private void OnEnable()
    {
        _observedVariable.VariableUpdated += UpdateDisplay;
    }
    private void OnDisable()
    {
        _observedVariable.VariableUpdated -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        if (_observedVariable.Value)
        {
            OnTrueResponse?.Invoke();
        }
        else
        {
            OnFalseResponse?.Invoke();
        }
    }
}
