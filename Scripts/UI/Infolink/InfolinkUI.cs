using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfolinkUI : MonoBehaviour, IUI
{
    [Header("UI Elements")]
    [SerializeField] private RawImage _portrait;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _dialogueText;
    
    [Header("Animation Settings")]
    [SerializeField] private float _portraitFadeTime = 0.5f;
    [SerializeField] private float _nameDelay = 0.3f;
    [SerializeField] private float _typewriterSpeed = 0.05f;
    [SerializeField] private float _autoCloseDelay = 2f;
    
    private Coroutine _currentAnimation;
    private string _fullDialogue;

    public bool _isOpen => gameObject.activeSelf;
    public UIPriority _priority => UIPriority.InfoLink;

    private void Awake()
    {
        // Initialize hidden
        ResetUI();
    }

    public void InitialiseInfoLink(Texture2D portrait, string name, string dialogue)
    {
        // Store references
        _portrait.texture = portrait;
        _nameText.text = name;
        _fullDialogue = dialogue;
        
        // Reset before showing
        ResetUI();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        if (_currentAnimation != null) StopCoroutine(_currentAnimation);
        _currentAnimation = StartCoroutine(OpeningSequence());

    }

    private IEnumerator OpeningSequence()
    {
        // 1. Fade in portrait
        yield return StartCoroutine(FadeImage(_portrait, 0, 1, _portraitFadeTime));
        
        // 2. Show name after delay
        yield return new WaitForSeconds(_nameDelay);
        _nameText.color = Color.white;
        
        // 3. Typewriter effect
        _dialogueText.text = "";
        for (int i = 0; i <= _fullDialogue.Length; i++)
        {
            _dialogueText.text = _fullDialogue.Substring(0, i);
            yield return new WaitForSeconds(_typewriterSpeed);
        }
        
        // 4. Auto-close after delay
        yield return new WaitForSeconds(_autoCloseDelay);
        Close();
    }

    private IEnumerator FadeImage(RawImage image, float from, float to, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, elapsed / duration);
            image.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    public void Close()
    {
        if (_currentAnimation != null) 
        {
            StopCoroutine(_currentAnimation);
            _currentAnimation = null;
        }
        ResetUI();
         gameObject.SetActive(false);
        UIManager.Instance.CloseInfoLink();
    }

    private void ResetUI()
    {
        // _portrait.color = new Color(1, 1, 1, 0);
        // _nameText.color = new Color(1, 1, 1, 0);
        _dialogueText.text = "";
    }
}