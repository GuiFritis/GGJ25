using UnityEngine;

public class SetPlayerColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Color _color;

    public void SetColor()
    {
        _playerSprite.color = _color;
    }
}
