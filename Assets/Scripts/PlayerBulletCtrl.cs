using UnityEngine;
using System.Collections;

public class PlayerBulletCtrl : MonoBehaviour {

    public Vector2 velocity;

    Rigidbody2D rb;

    PlayerCtrl control;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindWithTag("Player");
        control = player.GetComponent<PlayerCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = velocity;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameCtrl.instance.BulletHitEnemy(collision.gameObject.transform);
            control.modifyLife(1);
            Destroy(gameObject);
        }
        //else if (collision.gameObject.CompareTag("Player"))
        {
            //PlayerCtrl.modifyLife(-1);
            //Destroy(gameObject);

        }
    }

}
