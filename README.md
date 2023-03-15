# HoloLen_LSL_Netcode

## Running on HoloLens Instructions
* In ConnectionManager game object, enter IP address of HoloLens and set "Network Mode" as Server
* Disable LSL game object
* Enable Gaze Cursor script in the Sphere game object
* File -> Build -> Add Open Scenes -> UWP Remote Device (add credentials) -> Build and Run

## Running on PC Instructions
* In ConnectionManager game object, enter IP address of HoloLens and set "Network Mode" as Client
* Enable LSL game object
* Disable Gaze Cursor script in the Sphere game object
* Open LabRecorder and press Start
* Open Sigviewer and open the most recent file from LabRecorder

## Data Collected
1. Headset Position Tracking
    * FirstLSLTest script tracks headset position (represented by white sphere game object) then streams the x, y, z through channels 0-2
2. Headset Rotation Tracking
    * FirstLSLTest script tracks headset rotation (Euler Angles) then streams the x, y, z through channels 3-5
3. Eye Gaze Position Tracking
    * added Network Transform and Network Object to Sphere game object
    * followed tutorial on how to set up configurations https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk2/features/input/eye-tracking/eye-tracking-basic-setup?view=mrtkunity-2022-05#a-note-on-the-gazeinput-capability
    * added Gaze Cursor script to Sphere object so that the purple sphere moves to gaze direction (looking at the background, no object hit with gaze) or gaze target (looking at a game object) based on eye tracking
    * FirstLSLTest script tracks sphere position then streams the x, y, z through channels 6-8

## Importing Package Instructions
* install MRTK (I followed a tutorial https://learn.microsoft.com/en-us/training/paths/beginner-hololens-2-tutorials/ )
* download our package
* In Unity, Assets -> Import Package

