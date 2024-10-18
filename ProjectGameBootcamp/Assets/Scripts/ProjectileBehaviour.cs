using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;

    // Start is called before the first frame update
    void Start()
    {
        /* if (Thrown) {
             var direction = transform.right + Vector3.up;
             GetComponent<Rigidbbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
         }
         transform.Translate(LaunchOffset);

         Destroy(gameObject, 5);
     }

     // Update is called once per frame
     void Update()
     {
         if (!Thrown)
         {
             transform.position += -transform.right * Speed * Time.deltaTime;

         }
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
         var enemy = collision.collider.GetComponent<EnemyBehaviour>();
         if (enemy) {
             enemy.TakeHit(1);
         }
         Destroy(gameObject);*/
     }
    }

