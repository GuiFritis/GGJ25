using UnityEngine;
using Utils;

public class AudioPlayer : MonoBehaviour, IPoolItem
{
    [SerializeField] private AudioSource _audioSource;
    public SFX_Pool pool;

    private void Update()
    {
        if(_audioSource.clip != null && !_audioSource.isPlaying)
        {
            pool.ReturnPoolItem(this);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void GetFromPool()
    {
        gameObject.SetActive(true);
    }

    public void ReturnToPool()
    {
        _audioSource.clip = null;
        gameObject.SetActive(false);
    }
}
