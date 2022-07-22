using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_controller : MonoBehaviour
{
    [Header("Input Setting")]
    
    [Tooltip("Input from Player movements")][SerializeField] InputAction movement;
    [SerializeField] InputAction FireAction;

    [Header("General Setup Setting")]
    [Tooltip("How fast ship moves up and down u[on players input")]
    [SerializeField] float controlSpeed = 10f;
    [Tooltip("how far player can go in x direction")][SerializeField] float xRange = 10f;
    [Tooltip("how far player can go in y direction")][SerializeField] float yRange = 7f;

    [Header("Laser Gun Array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers;

    
    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;
    
     [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;
    

    float xThrow, yThrow;


    void OnEnable() 
    {
        movement.Enable();
        FireAction.Enable();
    }

    void OnDisable() 
    {
        movement.Disable();
        FireAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }

    void ProcessTranslation()
    {
        xThrow = movement.ReadValue<Vector2>().x;         //float horizontalThrow = Input.GetAxis("Horizontal");
        yThrow = movement.ReadValue<Vector2>().y;         //float verticalThrow = Input.GetAxis("Vertical");

        float xoffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPOS = transform.localPosition.x + xoffset;
        float clampedXPOS = Mathf.Clamp(rawXPOS, -xRange, xRange);

        float yoffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPOS = transform.localPosition.y + yoffset;
        float clampedYPOS = Mathf.Clamp(rawYPOS, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPOS, clampedYPOS, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPostion = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPostion + pitchDueToControl;


        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    void ProcessFiring()
    {
        
        if(FireAction.ReadValue<float>() > 0.5)
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }
    void SetLasersActive(bool state)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = state;
        }
    }
    
}
