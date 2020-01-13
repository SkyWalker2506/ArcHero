using System;
using System.Collections.Generic;
using UnityEngine;

public class FrequentlyShotPowerUp : PowerUp
{
    public new static Action PowerUpActivated;
    public new static Action PowerUpDeActivated;

    public override void ActivatePowerUp()
    {
        PlayerShotBehaviour.MultiplyShotInterval(.5f);
        PowerUpActivated?.Invoke();
        base.ActivatePowerUp();
    }

    public override void DeActivatePowerUp()
    {
        PlayerShotBehaviour.MultiplyShotInterval(2);
        PowerUpDeActivated?.Invoke();
        base.DeActivatePowerUp();
    }
}