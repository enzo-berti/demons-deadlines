using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneText : MonoBehaviour
{
    [SerializeField] [TextArea] private List<string> _dialogueLines;
    private int _lineIndex = 0;

    private TMP_Text _text;
    public CanvasGroup _group;

    [SerializeField]
    private List<AudioClip> phoneClips;
    [SerializeField] private AudioSource phoneAudio;
    [SerializeField] private AudioSource phoneMusic;

    [SerializeField] private AudioClip hangPhone;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _group.alpha = 0;
    }

    private void OnValidate()
    {
        if (_dialogueLines.Count > 0)
        {
            if (_text == null)
            {
                _text = GetComponent<TMP_Text>();
            }
            _text.SetText(_dialogueLines[0]);
        }
    }

    public bool TryStartPhoneCall()
    {
        if (_lineIndex == _dialogueLines.Count)
        {
            return false;
        }

        StartPhoneCall();

        return true;
    }

    public void StartPhoneCall()
    {
        _text.SetText(_dialogueLines[_lineIndex]);

        phoneAudio.clip = phoneClips[_lineIndex];
        phoneAudio.Play();
        phoneMusic.Play();

        _group.alpha = 1;
        _lineIndex++;
    }

    public void StopPhoneCall()
    {
        phoneMusic.Stop();

        phoneAudio.clip = hangPhone;
        phoneAudio.Play();

        _group.alpha = 0;
    }

    public bool IsTextFinished()
    {
        // need a better way to check
        return !phoneAudio.isPlaying;
    }
}
