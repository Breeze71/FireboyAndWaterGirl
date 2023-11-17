using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCheck : MonoBehaviour, ICheck
{
    [SerializeField] private LayerMask checkMask;
    [SerializeField] private float radius;

    public bool Check()
    {                                                                 
        return Physics2D.OverlapCircle(transform.position, radius, checkMask);
    }

    private void OnDrawGizmos()
    {
        if(transform == null)   return;

        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, radius);
    }   
}
