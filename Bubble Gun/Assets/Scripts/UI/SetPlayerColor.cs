using UnityEngine;

public class SetPlayerColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;

    public void SetColor(Color color)
    {
        _playerSprite.color = color;
    }
}
