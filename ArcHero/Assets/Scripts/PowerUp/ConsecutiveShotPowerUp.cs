using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveShotPowerUp : PowerUp
{
    public new static Action PowerUpActivated;
    public new static Action PowerUpDeActivated;
    [SerializeField]List<Vector3> arrowDirections = new List<Vector3>();
    public override void ActivatePowerUp()
    {
        PlayerShotBehaviour.AddShotAmount(1);
        PowerUpActivated?.Invoke();
        base.ActivatePowerUp();
    }

    public override void DeActivatePowerUp()
    {
        PlayerShotBehaviour.AddShotAmount(-1);
        PowerUpDeActivated?.Invoke();
        base.DeActivatePowerUp();
    }
}
