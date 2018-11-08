using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Pattern;

namespace Managers
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private List<GameObject> _soundObjects = null;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Initialize()
        {
            for (var i = 0; i < _soundObjects.Count; ++i)
            {
                _soundObjects[i].GetComponent<AudioSource>().clip = LoadManager.GetInstance.GetSoundModel(i).AudioClip;
                _soundObjects[i].GetComponent<AudioSource>().spatialBlend = LoadManager.GetInstance.GetSoundModel(i).SpatialBlend;
            }
        }
    }
}
