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
    private AudioClip mainBgmAudioClip; // ����ȭ�� BGM
    [SerializeField]
    private AudioClip[] sfxAudioClips; // ȿ������ �����ϴ� �迭

    Dictionary<string, AudioClip> sfxAudioClipsDic = new Dictionary<string, AudioClip>(); // ȿ�������� string���� ������ �� �ְ� ���� ��ųʸ�

    private void Awake()
    {
        if (Instance != this)
        { // �̹� SoundManager�� ������ �� SoundManager ����
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject); // ���� ������ ���

        // sfxPlayer�� (�ڵ�����) ������ �ڽ� ������Ʈ�� �ִ� AudioSource ������Ʈ
        GameObject sfxChild = new GameObject("SFX");
        sfxChild.transform.SetParent(transform);
        sfxPlayer = sfxChild.AddComponent<AudioSource>();

        // bgmPlayer�� (�ڵ�����) ������ �ڽ� ������Ʈ�� �ִ� AudioSource ������Ʈ
        GameObject bgmChild = new GameObject("BGM");
        bgmChild.transform.SetParent(transform);
        bgmPlayer = bgmChild.AddComponent<AudioSource>();

        // ȿ���� �迭�� �ִ� AudioClip���� ��ųʸ��� ����
        foreach (AudioClip audioclip in sfxAudioClips)
        {
            sfxAudioClipsDic.Add(audioclip.name, audioclip);
        }
    }

    // BGM �׽�Ʈ��
    // ������ �� �׽�Ʈ�� BGM�� �ڵ����� �����
    // ���� ��Ȳ�� ���߾� �����ϰų� ������ ��
    private void Start()
    {
        PlayBGMSound(0.1f);
    }

    // ȿ���� ��� : �̸��� �ʼ� �Ű�����, ������ ������ �Ű������� ����
    public void PlaySFXSound(string name, float volume = 1f)
    {
        if (sfxAudioClipsDic.ContainsKey(name) == false)
        {
            return;
        }
        sfxPlayer.PlayOneShot(sfxAudioClipsDic[name], volume * masterVolumeSFX);
    }

    // BGM ��� : ������ ������ �Ű������� ����
    public void PlayBGMSound(float volume = 1f)
    {
        volumeBGM = volume;

        bgmPlayer.loop = true; // BGM �����̹Ƿ� ������ ����
        bgmPlayer.volume = volume * masterVolumeBGM;

        bgmPlayer.clip = mainBgmAudioClip;
        bgmPlayer.Play();
    }

    // BGM �ߴ�
    public void StopBGMSound()
    {
        bgmPlayer.Stop();
    }

    // SFX ���� ����
    public void SetSFXVolume(float volume)
    {
        masterVolumeSFX = volume;
    }

    public float GetSFXVolume()
    {
        return masterVolumeSFX;
    }

    // BGM ���� ����
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