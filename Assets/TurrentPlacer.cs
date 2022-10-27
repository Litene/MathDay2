using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TurrentPlacer : MonoBehaviour {
    public Transform Turret;
    private readonly Vector3 _offsetY = new Vector3(0, 0.5f, 0);
    private Transform _camTrans;
    
    private void OnDrawGizmos() {
        if (Turret == null) return;

        _camTrans = Camera.main.transform;
        Vector3 origin = _camTrans.position;
        Vector3 direction = _camTrans.forward;
        Ray ray = new Ray(origin, direction);

        Gizmos.color = Color.white;
        if (Physics.Raycast(ray, out RaycastHit hit)) {

            Gizmos.DrawLine(origin, hit.point);
            Vector3 upDir = new Vector3(hit.normal.x, hit.normal.y, hit.normal.z);

            Gizmos.color = Color.green;
            Gizmos.DrawRay(hit.point, upDir);

            Vector3 forwardDir = Vector3.Cross(-_camTrans.forward, hit.normal);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(hit.point, Vector3.forward);

            // Turret.position = hit.point;
            // Turret.rotation = Quaternion.LookRotation(fordwardDir, updir);
        }
        else {
            return;
        }
    }
    
    Vector3 ReflectHalf(Vector3 inDir, Vector3 normal) {
        float proj = Vector3.Dot(inDir, normal);
        return inDir - 1 * proj * normal;
    }

    Vector3 AlignedVector() {
        return new Vector3();
    }
}