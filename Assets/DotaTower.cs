using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotaTower : MonoBehaviour {
    public float Range = 1;
    public Transform MousePos;
    public float ViewRadius = 180;

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Range);

        if (MousePos == null) {
            return;
        }

        Vector2 distToPlayer = MousePos.position - transform.position;
        Vector2 targetDirection;
        Gizmos.color = Color.red;
        Vector2 VectorProjectY = transform.up * Vector2.Dot(transform.up, distToPlayer.normalized) * Range; // could be scalar projection.
        Vector2 VectorProjectX = transform.right * Vector2.Dot(transform.right, distToPlayer.normalized) * Range; // could be scalar projection. 
        targetDirection = VectorProjectY + VectorProjectX;
        
        
        // forward is A, Objet is B, 
        // acos(a dot b) = angle
        // if localangle? > viewradius
        // if (distToPlayer.magnitude > Range) {
        //
        // }
        // else {
        //     targetDirection = MousePos.position;
        //     Gizmos.color = Color.green;
        // }

        Gizmos.DrawWireSphere(targetDirection, 0.4f);
    }
}