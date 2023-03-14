using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using LSL;
using LSL4Unity.Utils;
using HCIUD.HoloLSL;

public class FirstLSLTest : AFloatOutlet
{
    [Header("Synchronized Transform")]
    [SerializeField]
    private Transform sphere;


    public override List<string> ChannelNames
    {
        get { return new List<string>(new string[] { "headset x", "headset y", "headset z", "gaze x", "gaze y", "gaze z" }); }
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
        //Debug.Log(outlet.ToString());
        //var values = Camera.main.transform.position;
        //var values = transform.position;
        
        if(GlobalReferences.instance != null)
        {
            var gaze_values = sphere.position;
            var headset_values = GlobalReferences.instance._localPlayer.transform.position;
            //var values = transform.position;
            //Debug.Log(values);
            sample[0] = headset_values.x;
            sample[1] = headset_values.y;
            sample[2] = headset_values.z;
            sample[3] = gaze_values.x;
            sample[4] = gaze_values.y;
            sample[5] = gaze_values.z;
        }      

        return true;
    }
}
