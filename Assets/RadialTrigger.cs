using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrigger : MonoBehaviour {
        public float Radius = 3;
        public Transform Player;
       

        private void OnDrawGizmos() {
                Vector3 center = transform.position;
                Gizmos.DrawWireSphere(center, Radius);

                if (Player == null) return;

                Vector3 playerPos = Player.position;
                Vector3 delta = center - playerPos;
                float sqrtDistance = delta.sqrMagnitude;
                bool inside = sqrtDistance <= Radius * Radius;
                Gizmos.color = inside ? Color.red : Color.cyan;
                Gizmos.DrawWireSphere(playerPos, 1);
                


        }
}