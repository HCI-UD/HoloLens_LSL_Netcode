using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class GazeCursor : MonoBehaviour
{
    //private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        //meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        PointerUtils.SetGazePointerBehavior(PointerBehavior.AlwaysOn);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("test : " + CoreServices.InputSystem.EyeGazeProvider);
       // Debug.Log("test IsEyeTrackingEnabled: "+ CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabled);
      //  Debug.Log("test IsEyeCalibrationValid: " + CoreServices.InputSystem.EyeGazeProvider.IsEyeCalibrationValid);
       // Debug.Log("test IsEyeTrackingEnabledAndValid: " + CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid);
      //  Debug.Log("test IsEyeTrackingDataValid: " + CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingDataValid);
       

        // Do a raycast into the world based on the user's
        // head position and orientation.
        if (CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid)
        {
            // Debug.Log("enabled");
            // Show the object at the hit position of the user's eye gaze ray with a target.
            // We want the position always, not just when they hit a target object with gaze.
            if (CoreServices.InputSystem.EyeGazeProvider.GazeTarget) {
                gameObject.transform.position = CoreServices.InputSystem.EyeGazeProvider.HitPosition;
                //reset target hit info so gaze doesn't get stuck on the target when not looking at it
                CoreServices.InputSystem.EyeGazeProvider.UpdateGazeInfoFromHit(new MixedRealityRaycastHit());
            } else
            {
                gameObject.transform.position = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
                CoreServices.InputSystem.EyeGazeProvider.UpdateGazeInfoFromHit(new MixedRealityRaycastHit());
            }

            Debug.Log(CoreServices.InputSystem.EyeGazeProvider.GazeDirection);
        }
        else
        {
            Debug.Log("gaze not enabled");
           }
    }

}