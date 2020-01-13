using System;
using UnityEngine;

public class CopyCatPowerUp : PowerUp
{
    public new static Action PowerUpActivated;
    public new static Action PowerUpDeActivated;

    GameObject CopyCat; 

    public override void ActivatePowerUp()
    {
        if (!CopyCat)
            CopyCat = Instantiate(GameManager.Instance.Player, Environment.GetRandomPositionOnField(), Quaternion.Euler(0, UnityEngine.Random.Range(0,360), 0));

        PowerUpActivated?.Invoke();
        base.ActivatePowerUp();
    }

    public override void DeActivatePowerUp()
    {

        if (CopyCat)
            Destroy(CopyCat);
        PowerUpDeActivated?.Invoke();
        base.DeActivatePowerUp();
    }
}