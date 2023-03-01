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
        // Do a raycast into the world based on the user's
        // head position and orientation.
        if (CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid)
        {
            //Debug.Log("enabled");
            gameObject.transform.position = CoreServices.InputSystem.EyeGazeProvider.HitPosition;
        }
        else
        {
            Debug.Log("not enabled");
        }
        //Debug.Log(CoreServices.InputSystem.EyeGazeProvider.GazeTarget);

        
    }

}