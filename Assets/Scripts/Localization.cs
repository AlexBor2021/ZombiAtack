using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Localization  : MonoBehaviour
{
    public void SetEn()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
    public void SetRus()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }
    public void SetTur()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];
    }
}