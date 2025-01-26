using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    [SerializeField] private AudioClip _cheerSFX;
    [SerializeField] private ParticleSystem _cheerVFX;
    [SerializeField] private List<Transform> _crowd;
    [SerializeField] private List<Color> _colors;
    [SerializeField] private float _vibrationDuration = .5f;
    [SerializeField] private float _vibrationStrength = .15f;

    void Awake() {
        for (int i = 0; i < _crowd.Count; i++)
        {
            Transform crowdPerson = _crowd[i];
            Color color = _colors[i % _colors.Count];
            if(crowdPerson.TryGetComponent(out SpriteRenderer renderer))
            {
                renderer.color = color;
            }
        }
    }

    void Start()
    {
        DamageFeedback.OnSpriteChange += CrowdCheer;
        Vibrate();
    }


    private void CrowdCheer(DamageFeedback damageFeedback)
    {
        Vector3 scale;
        foreach (Transform crowdPerson in _crowd)
        {
            crowdPerson.DOKill();
            scale = crowdPerson.localScale;
            crowdPerson.DOScale(new Vector3(Random.Range(.15f, .3f), Random.Range(.15f, .3f), 0), .2f)
                .SetEase(Ease.OutQuad).SetRelative().OnComplete(
                    () => crowdPerson.DOShakeScale(.2f, 0.6f).SetLoops(5, LoopType.Yoyo).OnComplete(
                        () => crowdPerson.DOScale(scale, .3f)
                    )
                );
        }
        if(_cheerVFX != null)
        {
            _cheerVFX.Play();
        }
        if(_cheerSFX != null)
        {
            SFX_Pool.Instance.Play(_cheerSFX);
        }
        
        Vibrate();
    }

    private void Vibrate()
    {
        foreach (Transform crowdPerson in _crowd)
        {
            crowdPerson.DOShakeScale(_vibrationDuration, _vibrationStrength, 1).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
