using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour
{


    [SerializeField]private float speed;
    private int damage;
    public Vector3 dir;
    




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.position - transform.position;
        transform.Translate(dir * speed  * Time.deltaTime);
        
    }
}
