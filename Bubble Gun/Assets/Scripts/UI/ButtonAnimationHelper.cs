using System;
using System.Collections;
using UnityEngine;

public class ButtonAnimationHelper : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public Action OnAnimationFinished;

    private void OnValidate()
    {
        if(_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void ButtonClick()
    {
        _animator.SetTrigger("Clicked");
        StartCoroutine(DelayButtonAction());
    }

    private IEnumerator DelayButtonAction()
    {
        yield return new WaitForSeconds(0.6f);
        OnAnimationFinished?.Invoke();

    }
}
