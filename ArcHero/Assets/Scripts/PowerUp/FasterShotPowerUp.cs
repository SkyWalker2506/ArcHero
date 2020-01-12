using System;
using System.Collections.Generic;
using UnityEngine;

public class FasterShotPowerUp : PowerUp
{
    public new static Action PowerUpActivated;
    public new static Action PowerUpDeActivated;

    public override void ActivatePowerUp()
    {
        PlayerShotBehaviour.ActivateFasterShot();
        PowerUpActivated?.Invoke();
        base.ActivatePowerUp();
    }

    public override void DeActivatePowerUp()
    {
        PlayerShotBehaviour.DeActivateFasterShot();
        PowerUpDeActivated?.Invoke();
        base.DeActivatePowerUp();
    }
}