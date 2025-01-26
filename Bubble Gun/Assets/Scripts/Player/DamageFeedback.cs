using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DamageFeedback : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private CircleCollider2D _collider;
    [Header("Sprite change")]
    [SerializeField] private SpriteRenderer _spriteRendererBg;
    [SerializeField] private SpriteRenderer _spriteRendererFg;
    [SerializeField] private List<SpriteChange> _damagedSprites = new();
    public static Action<DamageFeedback> OnSpriteChange;
    [Header("Damage feedback")]
    [SerializeField] private ParticleSystem _spriteChangeVFX;
    // [SerializeField] private float _scaleLossRate = 0.1f;
    // [SerializeField] private float _colliderLossRate = 0.01f;
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
        _health.OnDamage += AlmostDead;
    }

    private void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     _health.TakeDamage(1);
        // }
    }

    private void DamageTaken(int currentHealth)
    {
        _spriteRendererFg.DOKill();
        _spriteRendererFg.transform.DOShakeScale(0.25f, 0.7f, 10, 10, true, ShakeRandomnessMode.Harmonic);
        if(_damagedSprites.Count > _spriteIndex && currentHealth == _damagedSprites[_spriteIndex].healthThreshold)
        {
            SpriteChange();
            OnSpriteChange?.Invoke(this);
            _spriteChangeVFX.Play();
        }
        // else
        // {
            // transform.localScale -= (Vector3)Vector2.one * _scaleLossRate;
            // _spriteRendererFg.transform.localScale -= (Vector3)Vector2.one * _scaleLossRate;
            // _collider.radius -= _colliderLossRate;
            // We tried to use DOTween here, but it didn't work as expected
            // transform.DOKill();
            // transform.DOScale(-(Vector3)Vector2.one * _scaleLossRate, .1f).SetEase(Ease.InOutElastic).SetRelative(true);
        // }
    }

    private void SpriteChange()
    {
        _spriteRendererFg.DOKill();
        _spriteRendererBg.sprite = _damagedSprites[_spriteIndex].spriteBackground;
        _spriteRendererFg.sprite = _damagedSprites[_spriteIndex].spriteForeground;
        _spriteRendererFg.transform.localScale = Vector2.one * _damagedSprites[_spriteIndex].scale;
        _collider.radius = _damagedSprites[_spriteIndex].colliderRadius;
        _spriteIndex++;
    }

    private void AlmostDead(int currentHealth) {
        if(currentHealth == 1)
        {
            _spriteRendererBg.DOColor(_health.AlmostDeadColor, 0.3f).SetLoops(-1, LoopType.Yoyo);
        }
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
