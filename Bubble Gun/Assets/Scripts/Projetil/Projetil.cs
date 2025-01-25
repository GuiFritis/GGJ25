using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Projetil : MonoBehaviour, IPoolItem
{
    [SerializeField]private float speed;
    private int damage = 1;
    private TrailRenderer trail;
    [SerializeField] private LayerMask _hitLayer;

    private void Start() {
        trail = GetComponentInChildren<TrailRenderer>(true);
    }

    public void GetFromPool()
    {
        gameObject.SetActive(true);
    }

    public void ReturnToPool()
    {
        trail.Clear();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed  * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((_hitLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            other.GetComponent<Health>().TakeDamage(damage);
            Debug.LogWarning("Acertou, miseravi");
        }
        
        ProjetilPool.Instance.ReturnPoolItem(this);
    }
}
