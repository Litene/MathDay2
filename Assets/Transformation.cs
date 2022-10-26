using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour {
    public Vector2 LocalCord;
    // Start is called before the first frame update
    private void OnDrawGizmos() {
        Vector2 worldPos = LocalToWorld(LocalCord);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(worldPos, 0.2f);
    }

    private Vector2 LocalToWorld(Vector2 local) {
        Vector2 position = transform.position;
        position += local.x * (Vector2)transform.right;
        position += local.y * (Vector2)transform.up;
        return position;
    }
}
