using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using Pattern;

namespace Managers
{
    public class LoadManager : Singleton<LoadManager>
    {

        private List<SoundModel> _soundList { get; set; }

        public const string DirectoryMusic = @"/Resources/Musics/";
        public const string ExtensionMusic = @".mp3";
        private bool _loadFlag = false;

        private struct SoundExtender
        {
            public SoundExtender(string name, float spatialBlend)
            {
                Name = name;
                SpatialBlend = spatialBlend;
            }

            public readonly string Name;
            public readonly float SpatialBlend;
        }

        protected override void Awake()
        {
            base.Awake();

            Initialize();
        }

        public void Initialize()
        {
            _soundList = _soundList ?? new List<SoundModel>();

            StartCoroutine(LoadSoundCoroutine());
        }

        private IEnumerator LoadCoroutine()
        {
            while (!_loadFlag)
            {
                yield return new WaitForSeconds(0.5f);
            }

            SoundManager.GetInstance.Initialize();
        }

        private IEnumerator LoadSoundCoroutine()
        {
            // 사용하는 백그라운드 뮤직들에 대한 리스트
            var soundExtenders = new List<SoundExtender>
            {
                new SoundExtender("washing_complete", 1.0f),
                new SoundExtender("ring", 1.0f),
                new SoundExtender("IU", 1.0f)
            };

            // 각각의 뮤직 파일들을 차례차례 리스트에 로드
            foreach (var soundExtender in soundExtenders)
            {
                // 정적 파일 할당
                var staticMusicFile =
                    new WWW(@"file://" + Application.dataPath +
                            DirectoryMusic + soundExtender.Name + ExtensionMusic);

                // 정적 파일 할당을 기다림
                while (!staticMusicFile.isDone)
                {
                    yield return new WaitForSeconds(1.0f);
                }

                // 정적으로 할당된 파일을 동적으로 로드
                var audioClip = (AudioClip)Resources.Load("Sounds/Musics/" + soundExtender.Name, typeof(AudioClip));

                // 동적으로 로드한 파일의 값이 없는 경우
                if (audioClip == null)
                {
                    _soundList.Add(null);
                }
                // 동적으로 성공적으로 로드에 성공한 경우
                else
                {
                    _soundList.Add(new SoundModel(audioClip, soundExtender.SpatialBlend));
                }
            }

            _loadFlag = true;
            yield return null;
        }

        public SoundModel GetSoundModel(int index)
        {
            return _soundList[index];
        }
    }
}