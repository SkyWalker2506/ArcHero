using System;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    static int activePowerUps;
    static int activePowerUpLimit = 3;
    internal static bool isActivePowerLimitReached;
    bool isPowerActive;
    public static Action PowerUpActivated;
    public static Action PowerUpDeActivated;

    public virtual void ActivatePowerUp()
    {
        if (isActivePowerLimitReached)
            return;
        isPowerActive = true;
        activePowerUps++;
        isActivePowerLimitReached = activePowerUps >= activePowerUpLimit;
        PowerUpActivated?.Invoke();
    }

    public virtual void DeActivatePowerUp()
    {
        isPowerActive = false;
        activePowerUps--;
        isActivePowerLimitReached = activePowerUps >= activePowerUpLimit;
        PowerUpDeActivated?.Invoke();
    }

    public void TooglePowerUp()
    {
        if (isPowerActive)
            DeActivatePowerUp();
        else
            ActivatePowerUp();
    }
}