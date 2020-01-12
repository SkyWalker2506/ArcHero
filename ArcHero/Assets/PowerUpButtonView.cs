using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpButtonView : MonoBehaviour
{
    [SerializeField] Color activatedButtonColor;
    [SerializeField] Color deActivatedButtonColor;
    [SerializeField] Button multipleArrowPowerUpButton; 
    [SerializeField] Button consecutiveShotPowerUpButton;
    [SerializeField] Button consecutiveShotPowerUpButton2;



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
        consecutiveShotPowerUpButton2.image.color= Color.Lerp(deActivatedButtonColor, activatedButtonColor, Convert.ToInt32(pubm.isConsecutiveShotActive));
    }

    void SetButtonInteractable(PowerUpButtonModel pubm)
    {
        multipleArrowPowerUpButton.interactable = !pubm.isPowerLimitReached || (pubm.isPowerLimitReached && pubm.isMultipleShotActive);
        consecutiveShotPowerUpButton.interactable = !pubm.isPowerLimitReached || (pubm.isPowerLimitReached && pubm.isConsecutiveShotActive);
    }


}