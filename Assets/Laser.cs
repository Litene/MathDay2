using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public int maxBounces;

    private void OnDrawGizmos() {
        Vector2 origin = transform.position;
        Vector2 dir = transform.right;

        for (int i = 0; i < maxBounces; i++) {
            Ray ray = new Ray(origin, dir);
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                Gizmos.DrawWireSphere(hit.point, 0.1f);

                Gizmos.DrawLine(origin, hit.point);
                Vector2 reflected = Reflect(ray.direction, hit.normal);
                Gizmos.color = Color.cyan;
                //Gizmos.DrawLine(hit.point, (Vector2)hit.point + reflected);
                origin = hit.point;
                dir = reflected;
            }
        }
    }

    Vector2 Reflect(Vector2 inDir, Vector2 n) {
        float proj = Vector2.Dot(inDir, n);
        return inDir - 2 * proj * n;
    }
}