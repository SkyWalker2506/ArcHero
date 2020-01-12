using System;
using UnityEngine;

public class PowerUpButtonModel : MonoBehaviour
{
    internal bool isPowerLimitReached;
    internal bool isMultipleShotActive;
    internal bool isConsecutiveShotActive;
    internal bool isFasterShotActive;

    public static Action<PowerUpButtonModel> ModelChanged;

    internal void SetConsecutiveShot(bool value)
    {
        isConsecutiveShotActive = value;
        ModelChanged?.Invoke(this);
    }

    internal void SetMultipleShot(bool value)
    {
        isMultipleShotActive = value;
        ModelChanged?.Invoke(this);
    }

    internal void SetFasterShot(bool value)
    {
        isFasterShotActive = value;
        ModelChanged?.Invoke(this);
    }

    internal void SetPowerLimitReached(bool value)
    {
        isPowerLimitReached = value;
        ModelChanged?.Invoke(this);
    }
}