using UnityEngine;
using DG.Tweening;
public class DoKill : MonoBehaviour
{
    [SerializeField] private Health _health;
    [Header("Pop Animation")]
    [SerializeField] private SpriteRenderer _spriteRendererBg;
    [SerializeField] private SpriteRenderer _spriteRendererFg;
    [SerializeField] private float _popScale;
    [Space]
    [SerializeField] private Gun _gun;
    [SerializeField] private ParticleSystem _deathVFX;
    [SerializeField] private SOAudio _deathSFX;
    [SerializeField] private Animator anim;

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

    private void Kill(Health hp)
    {

        anim.SetTrigger("Death");
        _gun.gameObject.SetActive(false);
        transform.DOKill();
        _spriteRendererBg.DOKill();
        _spriteRendererFg.DOKill();
        transform.DOScale(Vector3.one * _popScale, .3f).SetEase(Ease.OutCubic);
        _spriteRendererBg.DOFade(0, .3f).SetEase(Ease.OutCubic);
        _spriteRendererFg.DOFade(0, .3f).SetEase(Ease.OutCubic);
        if(_deathVFX != null)
        {
            Instantiate(_deathVFX, transform.position, _deathVFX.transform.rotation).Play();
        }
        if(_deathSFX != null)
        {
            SFX_Pool.Instance.Play(_deathSFX);
        }
    }
}
