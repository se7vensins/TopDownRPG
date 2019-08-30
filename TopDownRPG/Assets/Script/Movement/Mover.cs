using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    Ray lastRay;
    // Update is called once per frame
    void Update()
    {
        UpdateAnim();
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
    }

    private void UpdateAnim()
    {
        Vector3 _velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 _localVelocity = transform.InverseTransformDirection(_velocity);
        float _speed = _localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed", _speed);
    }
}
