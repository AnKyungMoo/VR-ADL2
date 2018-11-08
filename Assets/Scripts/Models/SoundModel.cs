using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class SoundModel : MonoBehaviour
    {
        public AudioClip AudioClip { get; private set; }
        public float SpatialBlend { get; private set; }

        public SoundModel()
        {
            AudioClip = null;
            SpatialBlend = 1.0f;
        }

        public SoundModel(AudioClip audioClip, float spatialBlend)
        {
            this.AudioClip = audioClip;
            this.SpatialBlend = spatialBlend;
        }
    }
}