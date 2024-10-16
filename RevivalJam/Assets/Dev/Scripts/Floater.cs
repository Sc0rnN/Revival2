using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Floater : MonoBehaviour
{
    public WaterSurface water;
    public Rigidbody rb;
    public float depthBoatSub;
    public float displacementAmount;
    public int floaters;
    public float waterDrag;
    public float waterAngularDrag;

    WaterSearchParameters Search;
    WaterSearchResult SearchResult;

    void Start()
    {
    }
    private void Update()
    {
        rb.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);
        Search.startPositionWS = transform.position;
        water.ProjectPointOnWaterSurface(Search, out SearchResult);
        if (transform.position.y < SearchResult.projectedPositionWS.y)
        {
            //Debug.Log("Bateau Sous L'eau");
            float displacementMulti = Mathf.Clamp01((SearchResult.projectedPositionWS.y - transform.position.y) / depthBoatSub) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMulti, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMulti * -rb.linearVelocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMulti * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);   
        }
        else
        {
            //Debug.Log(rb.GetAccumulatedForce());
        }
    }
    
}
