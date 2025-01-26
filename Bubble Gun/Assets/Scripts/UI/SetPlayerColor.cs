using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerColor : MonoBehaviour
{
    [SerializeField] private ColorPicker colorPicker;
    [SerializeField] private Color _color;
    [SerializeField] PlayerId playerId;

    private Button buttonComponent;

    private void Start() {
        colorPicker.OnPlayer1Select += OnPlayer1Select;
        colorPicker.OnPlayer2Select += OnPlayer2Select;
        buttonComponent = GetComponent<Button>();
    }

    public void SetColor()
    {
        if(playerId == PlayerId.PLAYER_1) 
            colorPicker.SetColorP1(_color);
        else {
            colorPicker.SetColorP2(_color);
        }
    }

    private void OnPlayer1Select(Color color) {
        if (playerId == PlayerId.PLAYER_2) {
            if(color == _color) {
                buttonComponent.interactable = false;
            }
            else {
                buttonComponent.interactable = true;
            }
        }
    }

    private void OnPlayer2Select(Color color) {
        if (playerId == PlayerId.PLAYER_1) {
            if(color == _color) {
                buttonComponent.interactable = false;
            }
            else {
                buttonComponent.interactable = true;
            }
        }
    }
}
