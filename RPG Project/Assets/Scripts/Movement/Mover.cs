using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private NavMeshAgent navMeshAgent;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }


        UpdateAnimator();
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;
        RaycastHit hitInfo;
        bool isHitReturned = Physics.Raycast(ray, out hitInfo);
        
        if (isHitReturned)
        {
            navMeshAgent.destination = hitInfo.point;
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        animator.SetFloat("forwardSpeed", speed);
    }
}
