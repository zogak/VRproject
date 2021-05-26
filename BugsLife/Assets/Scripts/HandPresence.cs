using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class HandPresence : MonoBehaviour
{

    private InputDevice targetDevice;

    public List<GameObject> controllerPrefabs;

    private GameObject spawnedController;

    public InputDeviceCharacteristics controllerCharacteristics;

    public bool showContoller = false;
    public GameObject handmodelPrefab;
    private GameObject spawnedHandModel;

    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {

        TryInitialize();

    }

    private void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        //InputDeviceCharacteristics chars = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            Debug.Log(targetDevice.name);

            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);

            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.Log("Controller model not available, using the defualt model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }

        spawnedHandModel = Instantiate(handmodelPrefab, transform);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
        /*
        foreach(InputDevice device in devices)
        {
            Debug.Log(device.name + " " + device.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        */
    }

    private void UpdateHandAnimation()
    {


        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            spawnedHandModel.SetActive(!showContoller);
            spawnedController.SetActive(showContoller);
        }


        if (!showContoller)
        {
            UpdateHandAnimation();
        }
        /*
        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue)&& primaryButtonValue)
        {
            Debug.Log("Primary button was pressed");
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            Debug.Log("Trigger button was pressed enough: " + triggerValue);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
        {
            Debug.Log("Touchpad/stick: " + primary2DAxisValue);
        }
        */

    }

}
