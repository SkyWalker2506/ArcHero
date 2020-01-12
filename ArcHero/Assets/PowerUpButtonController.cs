﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpButtonController : MonoBehaviour
{
    [SerializeField]
    PowerUpButtonModel powerUpButtonModel;

    void Awake()
    {
        PowerUp.PowerUpActivated = SetPowerLimitReached;
        MultipleArrowPowerUp.PowerUpActivated = ActivateMultipleShotButton;
        MultipleArrowPowerUp.PowerUpDeActivated = DeActivateMultipleShotButton;
        ConsecutiveShotPowerUp.PowerUpActivated = ActivateConsecutiveShotButton;
        ConsecutiveShotPowerUp.PowerUpDeActivated = DeActivateConsecutiveShotButton;
    }

    void ActivateMultipleShotButton()
    {
        powerUpButtonModel.SetMultipleShot(true);
    }

    void DeActivateMultipleShotButton()
    {
        powerUpButtonModel.SetMultipleShot(false);
    }

    void ActivateConsecutiveShotButton()
    {
        powerUpButtonModel.SetConsecutiveShot(true);
    }

    void DeActivateConsecutiveShotButton()
    {
        powerUpButtonModel.SetConsecutiveShot(false);
    }
    void SetPowerLimitReached()
    {
        powerUpButtonModel.SetPowerLimitReached(PowerUp.isActivePowerLimitReached);
    }
}