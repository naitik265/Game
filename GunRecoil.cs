using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public float recoilAmount = 2f;
    public float recoilSpeed = 5f;
    public float returnSpeed = 2f;

    private Vector3 originalPosition;
    private Vector3 currentRecoil;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // Apply recoil when shooting
        if (Input.GetButtonDown("Fire1"))
        {
            currentRecoil = new Vector3(-recoilAmount, Random.Range(-0.5f, 0.5f), 0);
        }

        // Smooth recoil effect
        transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition + currentRecoil, Time.deltaTime * recoilSpeed);
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, Time.deltaTime * returnSpeed);
    }
}