using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isPressed = false;
    [SerializeField] ButtonTracker tracker;

    public void PressButton()
    {
        isPressed = true;
        tracker.CheckPressed();
    }

    public bool CheckedPressed()
    {
        return isPressed;
    }
}
