using Godot;
using System;

public partial class RingControl : Node3D
{
    [Export]
    public MainControl Main { get; set; }
    [Export]
    public Node3D RingRig { get; set; }
    [Export]
    public MeshInstance3D VisualItem { get; set; }
    [Export]
    public CollisionObject3D Collider { get; set; }
    [Export]
    public StandardMaterial3D DefaultColor { get; set; }

    public Color RingColor { get { return ((StandardMaterial3D)VisualItem.MaterialOverride).AlbedoColor; } }

    public override void _Ready()
    {
        Collider.InputEvent += CollisionInput;
        VisualItem.MaterialOverride = DefaultColor;
    }
    
   	private void CollisionInput(Node camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, long shapeIdx)
	{
        if (Main != null && (@event is InputEventMouseButton mouseEvent))
        {
            if (mouseEvent.ButtonIndex == MouseButton.Left)
            {
                VisualItem.MaterialOverride = Main.MatLeft;
            }
            else if (mouseEvent.ButtonIndex == MouseButton.Middle)
            {
                VisualItem.MaterialOverride = Main.MatMiddle;
            }
            else if (mouseEvent.ButtonIndex == MouseButton.Right)
            {
                VisualItem.MaterialOverride = Main.MatRight;
            }
		}
	}

}
