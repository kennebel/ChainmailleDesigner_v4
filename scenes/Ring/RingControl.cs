using Godot;
using System;

public partial class RingControl : Node
{
    [Export]
    public MainControl Main { get; set; }
    [Export]
    public Node3D RingRig { get; set; }
    [Export]
    public MeshInstance3D VisualItem { get; set; }
    [Export]
    public CollisionObject3D Collider { get; set; }

    public override void _Ready()
    {
        Collider.InputEvent += CollisionInput;
    }
    
   	private void CollisionInput(Node camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, long shapeIdx)
	{
        if (Main != null && (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed))
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
