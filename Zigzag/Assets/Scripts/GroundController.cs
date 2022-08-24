using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{

    [SerializeField] private int deneme;

    public GameManager gameManager;

    private Rigidbody rb;
    [SerializeField] private bool gravityCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravityCheck = false;
        
    }

    
    void Update()
    {
        if (gravityCheck)
        {
            StartCoroutine(SetRigidBodyValues());
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            gravityCheck = true;
            
            
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ball"))
    //    {
    //        deneme++;
    //        Debug.Log(deneme);
    //    }
    //}



    public IEnumerator SetRigidBodyValues()
    {
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
        rb.useGravity = true;

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }

}
