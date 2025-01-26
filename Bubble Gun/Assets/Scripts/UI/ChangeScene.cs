using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, IButtonDelayed
{
    [SerializeField] private int _sceneIndex;
    [SerializeField] public Animator Transition;

    private void Start()
    {
        SetUpButtonDelay();
    }

    public void SetUpButtonDelay()
    {
        GetComponent<ButtonAnimationHelper>().OnAnimationFinished += ChangeSceneByIndex;
    }

    public void ChangeSceneByIndex()
    {
        Transition.SetTrigger("Start");
        SceneManager.LoadScene(_sceneIndex);        
    }
}
