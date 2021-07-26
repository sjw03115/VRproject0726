using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGyro : MonoBehaviour
{
    //float x, y;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        //x = 0;
        //y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        this.transform.GetChild(0).Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        this.transform.GetChild(1).Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        //this.transform.GetChild(0).GetChild(0).GetChild(1).Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
    }

    public void SetZero()
    {
        //x = this.transform.GetChild(0).rotation.x;
        //y = this.transform.rotation.y;
        this.transform.localRotation = Quaternion.Euler(this.transform.GetChild(0).rotation.x, 0, 0);
        this.transform.GetChild(0).localRotation = Quaternion.Euler(0, this.transform.localRotation.y, 0);
    }

    public void ChangeCamera()
    {
        this.transform.GetChild(0).GetChild(0).gameObject.SetActive(!this.transform.GetChild(0).GetChild(0).gameObject.activeSelf);
        this.transform.GetChild(0).GetChild(1).gameObject.SetActive(!this.transform.GetChild(0).GetChild(1).gameObject.activeSelf);
        //this.transform.GetChild(0).GetChild(2).gameObject.SetActive(!this.transform.GetChild(0).GetChild(2).gameObject.activeSelf);
    }
}
