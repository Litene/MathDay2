using System;
using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TurretController : MonoBehaviour {
    public float Range = 1;
    public float ViewRadius = 90;
    public float Height = 0.5f;

    public Transform playerTrans;
    public bool Rotating;
    private float _speed = 3f;

    // public 
    private void Start() {
    }

    private void Update() {
        Vector3 distanceToPlayer = playerTrans.position - transform.position;
        float dotProduct = Vector3.Dot(transform.forward, distanceToPlayer.normalized);
        Debug.DrawRay(transform.position, transform.forward * Range, Color.cyan);
        if (Mathf.Acos(dotProduct) * Mathf.Rad2Deg < ViewRadius * 0.5f && distanceToPlayer.magnitude < Range &&
            WithinHeightLimit()) {
            //StartCoroutine(RotateTowardsPlayer(distanceToPlayer));
            float step = _speed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, distanceToPlayer, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(new Vector3(transform.rotation.x, newDir.y, transform.rotation.z));

        }
        else {
            StopCoroutine(RotateTowardsPlayer(distanceToPlayer));
        }
    }

    private Vector3 ConvertWorldToLocal(Vector3 worldPos) {
        // make into transformation matrix
        float posX = Vector3.Dot(transform.right, worldPos);
        float posY = Vector3.Dot(transform.up, worldPos);
        float posZ = Vector3.Dot(transform.forward, worldPos);
        return new Vector3(posX, posY, posZ);
    }

    private bool WithinHeightLimit() {
        // this works
        if (ConvertWorldToLocal(playerTrans.position - transform.position).y >= Height * 0.5f ||
            ConvertWorldToLocal(playerTrans.position - transform.position).y <= Height * -0.5f) {
            return false;
        }

        return true;
    }

    private IEnumerator RotateTowardsPlayer(Vector3 signedDistanceToPlayer) {
        Rotating = true;
        Vector3 targetDir = signedDistanceToPlayer;
        //Debug.Log($"targetDir = {targetDir} transform.rotation = {transform.rotation}");
        //    transform.rotation = Quaternion.LookRotation(signedDistanceToPlayer.z, signedDistanceToPlayer.y);
        while (Mathf.Abs(transform.rotation.y - targetDir.y) > 0.2f) {
            
        }

        //transform.rotation = quaternion.Euler(targetDir);

        Rotating = false;
        yield return null;
    }
}