using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class SmoothMouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes Axes = RotationAxes.MouseXAndY;
    public float SensitivityX = 15F;
    public float SensitivityY = 15F;
    public float MinimumX = -360F;
    public float MaximumX = 360F;
    public float MinimumY = -60F;
    public float MaximumY = 60F;
    float _rotationX = 0F;
    float _rotationY = 0F;
    private List<float> rotArrayX = new List<float>();
    float _rotAverageX = 0F;
    private List<float> rotArrayY = new List<float>();
    float _rotAverageY = 0F;
    public float FrameCounter = 20;
    Quaternion _originalRotation;

    void Update()
    {
        if (Axes == RotationAxes.MouseXAndY)
        {
            //Resets the average rotation
            _rotAverageY = 0f;
            _rotAverageX = 0f;

            //Gets rotational input from the mouse
            _rotationY += Input.GetAxis("Mouse Y") * SensitivityY;
            _rotationX += Input.GetAxis("Mouse X") * SensitivityX;

            //Adds the rotation values to their relative array
            rotArrayY.Add(_rotationY);
            rotArrayX.Add(_rotationX);

            //If the arrays length is bigger or equal to the value of frameCounter remove the first value in the array
            if (rotArrayY.Count >= FrameCounter)
            {
                rotArrayY.RemoveAt(0);
            }

            if (rotArrayX.Count >= FrameCounter)
            {
                rotArrayX.RemoveAt(0);
            }

            //Adding up all the rotational input values from each array
            for (int j = 0; j < rotArrayY.Count; j++)
            {
                _rotAverageY += rotArrayY[j];
            }

            for (int i = 0; i < rotArrayX.Count; i++)
            {
                _rotAverageX += rotArrayX[i];
            }

            //Standard maths to find the average
            _rotAverageY /= rotArrayY.Count;
            _rotAverageX /= rotArrayX.Count;

            //Clamp the rotation average to be within a specific value range
            _rotAverageY = ClampAngle(_rotAverageY, MinimumY, MaximumY);
            _rotAverageX = ClampAngle(_rotAverageX, MinimumX, MaximumX);

            //Get the rotation you will be at next as a Quaternion
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotAverageY, Vector3.left);
            Quaternion xQuaternion = Quaternion.AngleAxis(_rotAverageX, Vector3.up);

            //Rotate
            transform.localRotation = _originalRotation * xQuaternion * yQuaternion;
        }
        else if (Axes == RotationAxes.MouseX)
        {
            _rotAverageX = 0f;
            _rotationX += Input.GetAxis("Mouse X") * SensitivityX;
            rotArrayX.Add(_rotationX);
            if (rotArrayX.Count >= FrameCounter)
            {
                rotArrayX.RemoveAt(0);
            }

            for (int i = 0; i < rotArrayX.Count; i++)
            {
                _rotAverageX += rotArrayX[i];
            }

            _rotAverageX /= rotArrayX.Count;
            _rotAverageX = ClampAngle(_rotAverageX, MinimumX, MaximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(_rotAverageX, Vector3.up);
            transform.localRotation = _originalRotation * xQuaternion;
        }
        else
        {
            _rotAverageY = 0f;
            _rotationY += Input.GetAxis("Mouse Y") * SensitivityY;
            rotArrayY.Add(_rotationY);
            if (rotArrayY.Count >= FrameCounter)
            {
                rotArrayY.RemoveAt(0);
            }

            for (int j = 0; j < rotArrayY.Count; j++)
            {
                _rotAverageY += rotArrayY[j];
            }

            _rotAverageY /= rotArrayY.Count;
            _rotAverageY = ClampAngle(_rotAverageY, MinimumY, MaximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotAverageY, Vector3.left);
            transform.localRotation = _originalRotation * yQuaternion;
        }
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
            rb.freezeRotation = true;
        _originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }

            if (angle > 360F)
            {
                angle -= 360F;
            }
        }

        return Mathf.Clamp(angle, min, max);
    }
}