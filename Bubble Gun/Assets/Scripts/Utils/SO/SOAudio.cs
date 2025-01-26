using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Audio")]
public class SOAudio : ScriptableObject
{
    public List<AudioClip> audioClips = new();
    [Header("Pitch")]
    [Range(1f, 1000f)]
    public float pitch = 100f;
    public bool randomizePith = false;
    [Tooltip("The range to witch the pitch can be randomized")]
    public float pitchRange = 0f;
    [Range(-80f, 20f)]
    public float volume = 0f;
}
