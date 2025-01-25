using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoKill : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private SpriteRenderer _spriteRendererBg;
    [SerializeField] private SpriteRenderer _spriteRendererFg;
    [SerializeField] private float _popScale;
    [SerializeField] private Gun _gun;

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

        if(_health == null)
        {
            _health = GetComponent<Health>();
        }

        if(_gun == null) 
        {
            _gun = GetComponentInChildren<Gun>();
        }
    }

    private void Start()
    {
        _health.OnKilled += Kill;
    }

    private void Kill()
    {
        _gun.gameObject.SetActive(false);
        transform.DOKill();
        _spriteRendererBg.DOKill();
        _spriteRendererFg.DOKill();
        transform.DOScale(Vector3.one * _popScale, .3f).SetEase(Ease.OutCubic).OnComplete(() => Destroy(gameObject));
        _spriteRendererBg.DOFade(0, .3f).SetEase(Ease.OutCubic);
        _spriteRendererFg.DOFade(0, .3f).SetEase(Ease.OutCubic);
    }
}
