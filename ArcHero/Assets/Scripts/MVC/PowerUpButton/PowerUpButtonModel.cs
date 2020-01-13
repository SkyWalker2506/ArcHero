using System;
using UnityEngine;

public class PowerUpButtonModel : MonoBehaviour
{
    internal bool isPowerLimitReached;
    internal bool isMultipleShotActive;
    internal bool isConsecutiveShotActive;
    internal bool isFrequentlyShotActive;
    internal bool isFasterShotActive;
    internal bool isCopyCatActive;

    public static Action<PowerUpButtonModel> ModelChanged;

    internal void SetPowerLimitReached(bool value)
    {
        isPowerLimitReached = value;
        ModelChanged?.Invoke(this);
    }

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

    internal void SetFrequentlyShot(bool value)
    {
        isFrequentlyShotActive = value;
        ModelChanged?.Invoke(this);
    }

    internal void SetFasterShot(bool value)
    {
        isFasterShotActive = value;
        ModelChanged?.Invoke(this);
    }

    internal void SetCopyCat(bool value)
    {
        isCopyCatActive = value;
        ModelChanged?.Invoke(this);
    }
}