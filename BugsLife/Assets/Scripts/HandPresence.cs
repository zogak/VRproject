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

    public bool showController = false;
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

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);


        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            Debug.Log(targetDevice.name);

            // get the controller prefab that matches the name of the target device
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);

            if (prefab)
            {
                // controller was found
                // spawn the controller prefab at the location of the hand
                spawnedController = Instantiate(prefab, transform);
                Debug.Log("controller instantiated well");

            }
            else  // controller is unknown
            {
                Debug.Log("Controller model not available, using the default model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
                Debug.Log("default controller instantiated");
            }
            spawnedHandModel = Instantiate(handmodelPrefab, transform);
            Debug.Log("handmodel instantiated");
            handAnimator = spawnedHandModel.GetComponent<Animator>();
            Debug.Log("Animator get");
        }


    }

    private void UpdateHandAnimation()
    {

        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
        {
            handAnimator.SetFloat("Trigger", triggerValue);
            Debug.Log("Trigger");
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
        {
            handAnimator.SetFloat("Grip", gripValue);
            Debug.Log("Grip");
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
            Debug.Log("try it again");
            TryInitialize(); 
        }
        else
        {
            spawnedHandModel.SetActive(!showController);
            spawnedController.SetActive(showController);
            Debug.Log("set active");
        }

        if (!showController)
        {
             UpdateHandAnimation();
        }
        

    }
}