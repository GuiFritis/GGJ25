using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreen : MonoBehaviour, IButtonDelayed
{
    [SerializeField] private GameObject _hideScreen;
    [SerializeField] private GameObject _showScreen;

    private void Start()
    {
        SetUpButtonDelay();
    }
    
    public void SetUpButtonDelay()
    {
        GetComponent<ButtonAnimationHelper>().OnAnimationFinished += ShowScreen;
    }

    public void ShowScreen()
    {
        _hideScreen.SetActive(false);
        _showScreen.SetActive(true);
    }
}
