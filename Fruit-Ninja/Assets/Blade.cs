using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailprefab;
    public float minCuttingVelocity = .001f;
    bool isCutting = false;
    Vector2 previousPosition;

    GameObject currentBladeTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startCutting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            stopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if(velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }
    void startCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailprefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void stopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
}
