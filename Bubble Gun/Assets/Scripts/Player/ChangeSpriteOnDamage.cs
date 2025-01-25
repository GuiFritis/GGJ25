using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOnDamage : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private SpriteRenderer _spriteRendererBg;
    [SerializeField] private SpriteRenderer _spriteRendererFg;
    [SerializeField] private CircleCollider2D _collider;
    [SerializeField] private List<SpriteChange> _damagedSprites = new();
    [SerializeField] private float _scaleLossRate = 0.15f;
    private int _spriteIndex = 0;

    private void OnValidate()
    {
        if(_spriteRendererFg == null)
        {
            _spriteRendererFg = GetComponent<SpriteRenderer>();
        }

        if(_spriteRendererBg == null)
        {
            _spriteRendererBg = GetComponentInChildren<SpriteRenderer>();
        }

        if(_collider == null)
        {
            _collider = GetComponent<CircleCollider2D>();
        }

        if(_health == null)
        {
            _health = GetComponent<Health>();
        }
    }

    private void Start()
    {
        _health.OnDamage += DamageTaken;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _health.TakeDamage(1);
        }
    }

    private void DamageTaken(int currentHealth)
    {
        if(_damagedSprites.Count > _spriteIndex && currentHealth == _damagedSprites[_spriteIndex].healthThreshold)
        {
            SpriteChange();
        }
        else
        {
            transform.localScale -= (Vector3)Vector2.one * _scaleLossRate;
        }
    }

    private void SpriteChange()
    {
        _spriteRendererBg.sprite = _damagedSprites[_spriteIndex].spriteBackground;
        _spriteRendererFg.sprite = _damagedSprites[_spriteIndex].spriteForeground;
        transform.localScale = Vector2.one * _damagedSprites[_spriteIndex].scale;
        _collider.radius = _damagedSprites[_spriteIndex].colliderRadius;
        _spriteIndex++;
    }
}

[System.Serializable]
public struct SpriteChange
{
    public Sprite spriteBackground;
    public Sprite spriteForeground;
    public int healthThreshold;
    public float scale;
    public float colliderRadius;
}
