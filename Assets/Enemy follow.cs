using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfollow : MonoBehaviour {
    public GameObject player;


    private void Update() {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform)

            transform.localScale = scale;


    }
}
