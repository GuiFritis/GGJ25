using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _player1;
    [SerializeField] private SpriteRenderer _player2;

    
    [SerializeField] private Image _player1Representation;
    [SerializeField] private Image _player2Representation;

    public Action<Color> OnPlayer1Select;
    public Action<Color> OnPlayer2Select;


    private void Start() {
        Time.timeScale = 0f;

    }
    public void SetColorP1(Color color)
    {
        OnPlayer1Select.Invoke(color);
        _player1.color = color;
        _player1Representation.color = color;
    }

    public void SetColorP2(Color color)
    {
        OnPlayer2Select.Invoke(color);
        _player2.color = color;
        _player2Representation.color = color;
    }

    public Color GetColor(PlayerId playerId) {
        if(playerId == PlayerId.PLAYER_1) 
            return _player1.color;
        else {
            return _player2.color;
        }
    }

    public void StartGame() {
        Debug.Log("oi");
        gameObject.SetActive(false);
        Time.timeScale = 1f;

    }
}
