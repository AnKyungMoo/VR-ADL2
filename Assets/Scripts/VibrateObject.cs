using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateObject : MonoBehaviour
{
    private Vector3 _originPosition;
    private Quaternion _originRotation;
    public float shakeDecay = 0.00002f;
    public float shakeTime = .3f;
    public float shakeStrength = 0.02f;

    private float tempShakeTime = 0;
    
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
        if (tempShakeTime > 0)
        {
            //transform.position = _originPosition + Random.insideUnitSphere * tempShakeIntensity;
            transform.rotation = new Quaternion(
                _originRotation.x + Random.Range(-shakeStrength, shakeStrength) * .2f,
                _originRotation.y + Random.Range(-shakeStrength, shakeStrength) * .2f,
                _originRotation.z + Random.Range(-shakeStrength, shakeStrength) * .2f,
                _originRotation.w + Random.Range(-shakeStrength, shakeStrength) * .2f);
            tempShakeTime -= shakeDecay;
        }
        else if (tempShakeTime < 0)
        {
            gameObject.GetComponent<AudioSource>().Play();
            tempShakeTime = 0;
        }
    }

    public void Shake()
    {
        _originPosition = transform.position;
        _originRotation = transform.rotation;
        tempShakeTime = shakeTime;
    }
}
