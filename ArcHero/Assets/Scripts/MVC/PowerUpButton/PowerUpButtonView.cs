using System;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButtonView : MonoBehaviour
{
    [SerializeField] Color activatedButtonColor;
    [SerializeField] Color deActivatedButtonColor;
    [SerializeField] Button multipleArrowPowerUpButton; 
    [SerializeField] Button consecutiveShotPowerUpButton;
    [SerializeField] Button frequentlyShotPowerUpButton;
    [SerializeField] Button fasterShotPowerUpButton;
    [SerializeField] Button copyCatPowerUpButton;

    private void Awake()
    {
        PowerUpButtonModel.ModelChanged = UpdateView;
    }

    void UpdateView(PowerUpButtonModel pubm)
    {
        SetButtonColors(pubm);
        SetButtonInteractable(pubm);
    }

    void SetButtonColors(PowerUpButtonModel pubm)
    {
        multipleArrowPowerUpButton.image.color= Color.Lerp(deActivatedButtonColor, activatedButtonColor, Convert.ToInt32(pubm.isMultipleShotActive));
        consecutiveShotPowerUpButton.image.color= Color.Lerp(deActivatedButtonColor, activatedButtonColor, Convert.ToInt32(pubm.isConsecutiveShotActive));
        frequentlyShotPowerUpButton.image.color= Color.Lerp(deActivatedButtonColor, activatedButtonColor, Convert.ToInt32(pubm.isFrequentlyShotActive));
        fasterShotPowerUpButton.image.color= Color.Lerp(deActivatedButtonColor, activatedButtonColor, Convert.ToInt32(pubm.isFasterShotActive));
        copyCatPowerUpButton.image.color= Color.Lerp(deActivatedButtonColor, activatedButtonColor, Convert.ToInt32(pubm.isCopyCatActive));
    }

    void SetButtonInteractable(PowerUpButtonModel pubm)
    {
        multipleArrowPowerUpButton.interactable = !pubm.isPowerLimitReached || (pubm.isPowerLimitReached && pubm.isMultipleShotActive);
        consecutiveShotPowerUpButton.interactable = !pubm.isPowerLimitReached || (pubm.isPowerLimitReached && pubm.isConsecutiveShotActive);
        frequentlyShotPowerUpButton.interactable = !pubm.isPowerLimitReached || (pubm.isPowerLimitReached && pubm.isFrequentlyShotActive);
        fasterShotPowerUpButton.interactable = !pubm.isPowerLimitReached || (pubm.isPowerLimitReached && pubm.isFasterShotActive);
        copyCatPowerUpButton.interactable = !pubm.isPowerLimitReached || (pubm.isPowerLimitReached && pubm.isCopyCatActive);
    }
}