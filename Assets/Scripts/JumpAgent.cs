using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class JumpAgent : Agent
{
    public float JumpCooldown = 5.5f;
    public float Force = 25f;
    private Rigidbody rb = null;
    private Vector3 originalPosition = new Vector3(23.68312f, 0.5f, -0.004343987f);
    private bool isJumping = false;
    private GameObject obstacle = null;
    private float lastPositionX = 0f;
    private float jumpCooldownTimer = 0f;

    public override void Initialize()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        obstacle = GameObject.Find("Obstacle");
        jumpCooldownTimer = 0f;

    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {

        if (jumpCooldownTimer <= 0 && actionBuffers.DiscreteActions[0] == 1)
        {
            Thrust();
        }

        if (transform.localPosition.x > obstacle.transform.localPosition.x && lastPositionX < obstacle.transform.localPosition.x)
        {
            // Give positive reward for passing the obstacle
            AddReward(2f);
            EndEpisode();
        }

        lastPositionX = transform.position.x;
        jumpCooldownTimer -= Time.deltaTime;
        if (obstacle.transform.position.x<=-5f)
        {
            Debug.Log("resetting");
            EndEpisode();
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Agent positie   
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(this.obstacle.transform.localPosition);
        sensor.AddObservation(obstacle.transform.localPosition.x);
        sensor.AddObservation(transform.localPosition.x);
    }

    public override void OnEpisodeBegin()
    {
        isJumping = false;
        jumpCooldownTimer = 0f;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            discreteActionsOut[0] = 1;
        }

    }

    private void Thrust()
    {
        if (transform.position.y <= 0.5f)
        {
            rb.AddForce(Vector3.up * Force, ForceMode.Acceleration);
            AddReward(-0.05f);
            isJumping = true;
            jumpCooldownTimer = JumpCooldown;
        }
        
        if (isJumping && transform.position.y <= 0.5f)
        {
            AddReward(-0.1f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            //collision.gameObject.transform.position = new Vector3(23f, -2f, 0f);
            //collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            //collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            AddReward(-0.25f);
            Debug.Log("ending episode");
            EndEpisode();
        }
    }

}