using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Projetil : MonoBehaviour, IPoolItem
{
    [SerializeField]private float speed;
    private int damage;

    public void GetFromPool()
    {
        gameObject.SetActive(true);
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed  * Time.deltaTime);


        if(Mathf.Abs(transform.position.x) > 12 || Mathf.Abs(transform.position.y) > 5)
            ReturnToPool();


    }
}
