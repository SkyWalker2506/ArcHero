using System;
using System.Collections.Generic;
using UnityEngine;

public class FasterShotPowerUp : PowerUp
{
    public new static Action PowerUpActivated;
    public new static Action PowerUpDeActivated;

    public override void ActivatePowerUp()
    {
        PlayerShotBehaviour.MultiplyShotSpeed(1.5f);
        PowerUpActivated?.Invoke();
        base.ActivatePowerUp();
    }

    public override void DeActivatePowerUp()
    {
        PlayerShotBehaviour.MultiplyShotSpeed(2/3f);
        PowerUpDeActivated?.Invoke();
        base.DeActivatePowerUp();
    }
}