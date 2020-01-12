using System;
using UnityEngine;

public class PowerUpButtonModel : MonoBehaviour
{
    internal bool isPowerLimitReached;
    internal bool isMultipleShotActive;
    internal bool isConsecutiveShotActive;

    public static Action<PowerUpButtonModel> ModelChanged;

    internal void SetConsecutiveShot(bool value)
    {
        print("SetConsecutiveShot");
        isConsecutiveShotActive = value;
        ModelChanged?.Invoke(this);
    }

    internal void SetMultipleShot(bool value)
    {
        print("SetMultipleShot");
        isMultipleShotActive = value;
        ModelChanged?.Invoke(this);
    }

    internal void SetPowerLimitReached(bool value)
    {
        isPowerLimitReached = value;
        ModelChanged?.Invoke(this);
    }

}