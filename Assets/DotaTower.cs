using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotaTower : MonoBehaviour {
    public float Range = 1;
    public Transform MousePos;

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Range);

        if (MousePos == null) {
            return;
        }

        Vector2 distToPlayer = MousePos.position - transform.position;
        Vector2 targetDirection;
        if (distToPlayer.magnitude > Range) {
            Vector2 VectorProjectY = transform.up * Vector2.Dot(transform.up, distToPlayer.normalized) * Range; // could be scalar projection.
            Vector2 VectorProjectX = transform.right * Vector2.Dot(transform.right, distToPlayer.normalized) * Range; // could be scalar projection. 
            targetDirection = VectorProjectY + VectorProjectX;
        }
        else {
            targetDirection = MousePos.position;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetDirection, 0.4f);
    }
}