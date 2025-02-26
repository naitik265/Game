using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.1f;
    public float headBobAmount = 0.02f;
    public float headBobSpeed = 5f;

    private Vector3 originalPosition;
    private float bobbingTimer;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Smoothly follow player's rotation
        transform.position = player.position;

        // Head bobbing effect (walking immersion)
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            bobbingTimer += Time.deltaTime * headBobSpeed;
            float bobOffset = Mathf.Sin(bobbingTimer) * headBobAmount;
            transform.localPosition = originalPosition + new Vector3(0, bobOffset, 0);
        }
        else
        {
            bobbingTimer = 0;
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * smoothSpeed);
        }
    }
}