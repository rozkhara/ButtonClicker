using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundManager>();
            }

            return instance;
        }
    }

    private AudioSource bgmPlayer;
    private AudioSource sfxPlayer;

    private float masterVolumeSFX = 1f;
    private float masterVolumeBGM = 1f;

    private float volumeBGM = 1f;

    [SerializeField]
    private AudioClip mainBgmAudioClip; // 메인화면 BGM
    [SerializeField]
    private AudioClip[] sfxAudioClips; // 효과음들 지정하는 배열

    Dictionary<string, AudioClip> sfxAudioClipsDic = new Dictionary<string, AudioClip>(); // 효과음들을 string으로 관리할 수 있게 만든 딕셔너리

    private void Awake()
    {
        if (Instance != this)
        { // 이미 SoundManager가 있으면 이 SoundManager 삭제
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); // 여러 씬에서 사용

        // sfxPlayer는 (자동으로) 생성한 자식 오브젝트에 있는 AudioSource 컴포넌트
        GameObject sfxChild = new GameObject("SFX");
        sfxChild.transform.SetParent(transform);
        sfxPlayer = sfxChild.AddComponent<AudioSource>();

        // bgmPlayer는 (자동으로) 생성한 자식 오브젝트에 있는 AudioSource 컴포넌트
        GameObject bgmChild = new GameObject("BGM");
        bgmChild.transform.SetParent(transform);
        bgmPlayer = bgmChild.AddComponent<AudioSource>();

        // 효과음 배열에 있는 AudioClip들을 딕셔너리에 저장
        foreach (AudioClip audioclip in sfxAudioClips)
        {
            sfxAudioClipsDic.Add(audioclip.name, audioclip);
        }
    }

    // BGM 테스트용
    // 시작할 때 테스트용 BGM을 자동으로 재생함
    // 이후 상황에 맞추어 삭제하거나 변형할 것
    private void Start()
    {
        PlayBGMSound(0.1f);
    }

    // 효과음 재생 : 이름을 필수 매개변수, 볼륨을 선택적 매개변수로 지정
    public void PlaySFXSound(string name, float volume = 1f)
    {
        if (sfxAudioClipsDic.ContainsKey(name) == false)
        {
            return;
        }
        sfxPlayer.PlayOneShot(sfxAudioClipsDic[name], volume * masterVolumeSFX);
    }

    // BGM 재생 : 볼륨을 선택적 매개변수로 지정
    public void PlayBGMSound(float volume = 1f)
    {
        volumeBGM = volume;

        bgmPlayer.loop = true; // BGM 사운드이므로 루프로 설정
        bgmPlayer.volume = volume * masterVolumeBGM;

        bgmPlayer.clip = mainBgmAudioClip;
        bgmPlayer.Play();
    }

    // BGM 중단
    public void StopBGMSound()
    {
        bgmPlayer.Stop();
    }

    // SFX 볼륨 설정
    public void SetSFXVolume(float volume)
    {
        masterVolumeSFX = volume;
    }

    public float GetSFXVolume()
    {
        return masterVolumeSFX;
    }

    // BGM 볼륨 설정
    public void SetBGMVolume(float volume)
    {
        masterVolumeBGM = volume;
        bgmPlayer.volume = volumeBGM * masterVolumeBGM;
    }

    public float GetBGMVolume()
    {
        return masterVolumeBGM;
    }
}