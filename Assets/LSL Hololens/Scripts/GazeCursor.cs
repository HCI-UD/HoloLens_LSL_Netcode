using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;


namespace HCIUD.HoloLSL
{
    /// <summary>
    /// tracks the user's eye gaze by mirroring the purple sphere's location to where they are looking 
    /// </summary>
    public class GazeCursor : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // make sure eye tracking is enabled first
            // (if not, check configurations in unity: https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/input/eye-tracking/eye-tracking-basic-setup?view=mrtkunity-2022-05#a-note-on-the-gazeinput-capability
            // and configure setting in HoloLens: Settings->Calibration->Run Eye Calibration)
            if (CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid)
            {

                // Show the object at the hit position of the user's eye gaze ray with a target.
                // We want the position always, not just when they hit a target object with gaze.

                if (CoreServices.InputSystem.EyeGazeProvider.GazeTarget)
                {  // if user is looking at an object, the gaze is the hit on that target

                    gameObject.transform.position = CoreServices.InputSystem.EyeGazeProvider.HitPosition;

                    //reset target hit info so gaze doesn't get stuck on the last target when user is not looking at it anymore
                    CoreServices.InputSystem.EyeGazeProvider.UpdateGazeInfoFromHit(new MixedRealityRaycastHit());

                }
                else //otherwise if there is not a target the user is looking at then the gaze is the direction the user is looking
                {

                    gameObject.transform.position = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
                    CoreServices.InputSystem.EyeGazeProvider.UpdateGazeInfoFromHit(new MixedRealityRaycastHit());
                }
            }
            else
            {
               // Debug.Log("gaze not enabled"); //may show up at first because gaze is not enabled until callibrated, but it should stop showing up after callibration 
            }
        }

    }
}
