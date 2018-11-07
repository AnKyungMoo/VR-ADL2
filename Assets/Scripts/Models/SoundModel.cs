using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundModel : MonoBehaviour {
    private AudioClip _audioClip;
    private float _spatialBlend;

    public SoundModel()
    {
        _audioClip = null;
        _spatialBlend = 1.0f;
    }

    public SoundModel(AudioClip audioClip, float spatialBlend)
    {
        _audioClip = audioClip;
        _spatialBlend = spatialBlend;
    }
}
