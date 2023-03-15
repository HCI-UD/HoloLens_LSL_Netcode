using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using LSL;
using LSL4Unity.Utils;
using HCIUD.HoloLSL;

/// <summary>
/// sends Headset position and rotation and eye gaze position data from HoloLens to LabRecorder
/// </summary>
public class FirstLSLTest : AFloatOutlet
{
    [Header("Synchronized Transform")]
    [SerializeField]
    private Transform sphere;

    public override List<string> ChannelNames
    {
        get { return new List<string>(new string[] { "headset position x", "headset position y", "headset position z", "headset rotation x", "headset rotation y", "headset rotation z", "gaze position x", "gaze position y", "gaze position z" }); }
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Debug.Log("Try to connect LSL: " + LSL.LSL.library_version());
        Debug.Log(outlet.ToString());
        //Reset();
    }

    // Update is called once per frame
    protected override bool BuildSample()
    {
        
        if(GlobalReferences.instance != null)
        {
            var gaze_position_values = sphere.position;
            var headset_position_values = GlobalReferences.instance._localPlayer.transform.position;
            var headset_rotation_values = GlobalReferences.instance._localPlayer.transform.eulerAngles;

            sample[0] = headset_position_values.x;
            sample[1] = headset_position_values.y;
            sample[2] = headset_position_values.z;
            sample[3] = headset_rotation_values.x;
            sample[4] = headset_rotation_values.y;
            sample[5] = headset_rotation_values.z;
            sample[6] = gaze_position_values.x;
            sample[7] = gaze_position_values.y;
            sample[8] = gaze_position_values.z;
        }      

        return true;
    }
}
