using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateObject : MonoBehaviour
{
    private Vector3 _originPosition;
    private Quaternion _originRotation;
    public float shakeDecay = 0.002f;
    public float shakeIntensity = .3f;

    private float tempShakeIntensity = 0;

    /*
    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Shake"))
        {
            Shake();
        }
    }
    */

    void Update()
    {
        if (tempShakeIntensity > 0)
        {
            transform.position = _originPosition + Random.insideUnitSphere * tempShakeIntensity;
            transform.rotation = new Quaternion(
                _originRotation.x + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f,
                _originRotation.y + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f,
                _originRotation.z + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f,
                _originRotation.w + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f);
            tempShakeIntensity -= shakeDecay;
        }
        else if (tempShakeIntensity < 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            tempShakeIntensity = 0;
        }
    }

    public void Shake()
    {
        _originPosition = transform.position;
        _originRotation = transform.rotation;
        tempShakeIntensity = shakeIntensity;
    }
}
