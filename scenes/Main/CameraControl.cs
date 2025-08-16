using Godot;
using System;

public partial class CameraControl : Node3D
{
    [Export]
    public Node3D CameraRig { get; set; }
    [Export]
    public Camera3D TheCamera { get; set; }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionPressed("camera_pan_left")) { CameraRig.Translate(Vector3.Left); }
        if (Input.IsActionPressed("camera_pan_right")) { CameraRig.Translate(Vector3.Right); }
        if (Input.IsActionPressed("camera_pan_up")) { CameraRig.Translate(Vector3.Forward); }
        if (Input.IsActionPressed("camera_pan_down")) { CameraRig.Translate(Vector3.Back); }
 
        if (Input.IsActionJustPressed("camera_zoom_in"))
        {
            TheCamera.Size += 1;
        }
        if (Input.IsActionJustPressed("camera_zoom_out"))
        {
            TheCamera.Size -= 1;
        }
    }
}