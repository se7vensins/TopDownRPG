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
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnim();
    }

    public void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }

    private void UpdateAnim()
    {
        Vector3 _velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 _localVelocity = transform.InverseTransformDirection(_velocity);
        float _speed = _localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed", _speed);
    }
}
