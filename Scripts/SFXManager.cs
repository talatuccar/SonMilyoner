using System.Collections;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField] AudioDataSo audioDataSo;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        _audioSource.PlayOneShot(audioDataSo.GameStartSFX);
    }
    public void AnswerSFX(bool Iscorrect)
    {
        if (Iscorrect)
            StartCoroutine(PlaySoundForSeconds(audioDataSo.trueSFX, 3f));
        else
            StartCoroutine(PlaySoundForSeconds(audioDataSo.wrongSFX, 3f));
    }
    private IEnumerator PlaySoundForSeconds(AudioClip clip, float seconds)
    {
        _audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(seconds);
        _audioSource.Stop();
    }
    public void TimeIsUpSFX()
    {
        StartCoroutine(PlaySoundForSeconds(audioDataSo.TimeIsUpSFX, 3f));
    }
    public void HalfJokerSFX()
    {
        _audioSource.PlayOneShot(audioDataSo.HalfJokerSFX);
    }

    public void EasyAskSFX()
    {
        _audioSource.clip = audioDataSo.EasyAskSFX;
        _audioSource.loop = true;  
        _audioSource.Play();        
    }

    public void HardAskSFX()
    {
        _audioSource.clip = audioDataSo.HardAskSFX;
        _audioSource.loop = true;
        _audioSource.Play();
    }
    public void StopForAnswerSFX()
    {
        _audioSource.Stop();
    }
}
