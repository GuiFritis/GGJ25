using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _creditsScreen;

    public void ShowCredits()
    {
        _mainMenuScreen.SetActive(false);
        _creditsScreen.SetActive(true);
    }

    public void HideCredits()
    {
        _creditsScreen.SetActive(false);
        _mainMenuScreen.SetActive(true);
    }
}
