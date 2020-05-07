using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfLeftAndRight : MonoBehaviour
{
    [SerializeField] float strafSpeed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        HandlesStarf();
    }

    private void HandlesStarf()
    {
        if (Input.GetKey("a"))
        {
            transform.position -= new Vector3(strafSpeed * Mathf.Sin((transform.eulerAngles.y + 90) * (Mathf.PI / 180)) * Time.deltaTime, 0, strafSpeed * Mathf.Cos((transform.eulerAngles.y + 90) * (Mathf.PI / 180)) * Time.deltaTime);
        }
        else if (Input.GetKey("d"))
        {
            transform.position += new Vector3(strafSpeed * Mathf.Sin((transform.eulerAngles.y + 90) * (Mathf.PI / 180)) * Time.deltaTime, 0, strafSpeed * Mathf.Cos((transform.eulerAngles.y + 90) * (Mathf.PI / 180)) * Time.deltaTime);
        }
    }
}
