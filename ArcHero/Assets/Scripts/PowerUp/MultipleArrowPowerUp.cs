using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleArrowPowerUp : PowerUp
{

    public new static Action PowerUpActivated;
    public new static Action PowerUpDeActivated;

    [SerializeField]List<Vector3> arrowDirections = new List<Vector3>();

    public override void ActivatePowerUp()
    {
        foreach (Vector3 direction in arrowDirections)
        {
            PlayerShotBehaviour.AddDirection(direction);
        }
        PowerUpActivated?.Invoke();
        base.ActivatePowerUp();
    }

    public override void DeActivatePowerUp()
    {
        foreach (Vector3 direction in arrowDirections)
        {
            PlayerShotBehaviour.RemoveDirection(direction);
        }
        PowerUpDeActivated?.Invoke();
        base.DeActivatePowerUp();
    }
}
