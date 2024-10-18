using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] Transform projectilePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField] float launchForce = 1.0f;
    [SerializeField] float trajectoryTimeStep = 0.5f;
    [SerializeField] int trajectoryStepCount = 15;

    Vector2 velocity, startMousePos, currentMousePos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetKey(KeyCode.G))
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            velocity = startMousePos - currentMousePos * launchForce;
        }
        DrawTrajectory();
    }
    void DrawTrajectory()
    {
        Vector3[] position = new Vector3[trajectoryStepCount];
        for (int i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;

            position[i] = pos;
        }
        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(position);
    }
}

