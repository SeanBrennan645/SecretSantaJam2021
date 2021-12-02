using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTracker : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject Obstacle;

    public void CheckPressed()
    {
        foreach(Button button in buttons)
        {
            if (!button.CheckedPressed())
                return;
            else
                Obstacle.SetActive(false);
        }
    }
}
