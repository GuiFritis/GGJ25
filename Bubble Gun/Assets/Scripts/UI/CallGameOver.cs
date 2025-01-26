using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CallGameOver : MonoBehaviour
{
    [SerializeField] private List<Health> _playerHp;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private GameObject _gameObject;

    private void OnValidate()
    {
        if(_playerHp == null)
        {
            _playerHp = FindObjectsByType<Health>(FindObjectsSortMode.None).ToList();
        }
    }

    private void Awake()
    {
        foreach (Health hp in _playerHp)
        {
            hp.OnKilled += GameOver;
        }
    }

    private void GameOver(Health hp)
    {
        _gameObject.SetActive(true);
        Health health = _playerHp.Find(i => !i.Equals(hp));
        if(health.TryGetComponent(out PlayerMovement player))
        {
            string text = player.PlayerId.ToString().Replace("_", " ");
            _textMesh.text = $"{text} is a poping star!";
        }
    }
}
