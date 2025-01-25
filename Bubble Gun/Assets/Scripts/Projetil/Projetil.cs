using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Projetil : MonoBehaviour, IPoolItem
{
    [SerializeField]private float speed;
    private int damage = 1;
    private TrailRenderer trail;

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


        if(Mathf.Abs(transform.position.x) > 12 || Mathf.Abs(transform.position.y) > 5)
            ProjetilPool.Instance.ReturnPoolItem(this);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            other.GetComponent<Health>().TakeDamage(damage);
        }
        
        ProjetilPool.Instance.ReturnPoolItem(this);
    }
}
