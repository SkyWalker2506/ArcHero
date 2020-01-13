using UnityEngine;

public class PowerUpButtonController : MonoBehaviour
{
    [SerializeField]
    PowerUpButtonModel powerUpButtonModel;

    void Awake()
    {
        PowerUp.PowerUpActivated = SetPowerLimitReached;
        PowerUp.PowerUpDeActivated = SetPowerLimitReached;
        MultipleArrowPowerUp.PowerUpActivated = ActivateMultipleShotButton;
        MultipleArrowPowerUp.PowerUpDeActivated = DeActivateMultipleShotButton;
        ConsecutiveShotPowerUp.PowerUpActivated = ActivateConsecutiveShotButton;
        ConsecutiveShotPowerUp.PowerUpDeActivated = DeActivateConsecutiveShotButton;
        FrequentlyShotPowerUp.PowerUpActivated = ActivateFrequentlyShotButton;
        FrequentlyShotPowerUp.PowerUpDeActivated = DeActivateFrequentlyShotButton;
        FasterShotPowerUp.PowerUpActivated = ActivateFasterShotButton;
        FasterShotPowerUp.PowerUpDeActivated = DeActivateFasterShotButton;
        CopyCatPowerUp.PowerUpActivated = ActivateCopyCatButton;
        CopyCatPowerUp.PowerUpDeActivated = DeActivateCopyCatButton;
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

    void ActivateFrequentlyShotButton()
    {
        powerUpButtonModel.SetFrequentlyShot(true);
    }

    void DeActivateFrequentlyShotButton()
    {
        powerUpButtonModel.SetFrequentlyShot(false);
    }

    void ActivateFasterShotButton()
    {
        powerUpButtonModel.SetFasterShot(true);
    }

    void DeActivateFasterShotButton()
    {
        powerUpButtonModel.SetFasterShot(false);
    }

    void ActivateCopyCatButton()
    {
        powerUpButtonModel.SetCopyCat(true);
    }

    void DeActivateCopyCatButton()
    {
        powerUpButtonModel.SetCopyCat(false);
    }

    void SetPowerLimitReached()
    {
        powerUpButtonModel.SetPowerLimitReached(PowerUp.isActivePowerLimitReached);
    }
}