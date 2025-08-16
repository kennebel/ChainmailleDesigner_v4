using Godot;
using System;

public partial class RingControl : Node3D
{
	public enum ColorPick { Primary, Secondary, Tertiary }
	[Export]
	public MainControl Main { get; set; }
	[Export]
	public Node3D RingRig { get; set; }
	[Export]
	public MeshInstance3D VisualItem { get; set; }
	[Export]
	public CollisionObject3D Collider { get; set; }
	[Export]
	public StandardMaterial3D DefaultMaterial { get; set; }

	public Color RingColor { get { return ((StandardMaterial3D)VisualItem.MaterialOverride).AlbedoColor; } }

	private bool IsMouseEntered { get; set; }

	public override void _Ready()
	{
		VisualItem.MaterialOverride = DefaultMaterial;
	}

	private void CollisionInput(Node camera, InputEvent @event, Vector3 eventPosition, Vector3 normal, long shapeIdx)
	{
		if (Main != null && (@event is InputEventMouseButton mouseEvent))
		{
			if (mouseEvent.ButtonIndex == MouseButton.Left)
			{
				SetColor(ColorPick.Primary);
			}
			else if (mouseEvent.ButtonIndex == MouseButton.Middle)
			{
				SetColor(ColorPick.Secondary);
			}
			else if (mouseEvent.ButtonIndex == MouseButton.Right)
			{
				SetColor(ColorPick.Tertiary);
			}
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (IsMouseEntered)
		{
			if (Input.IsActionPressed("color_primary"))
			{
				SetColor(ColorPick.Primary);
			}
			else if (Input.IsActionPressed("color_secondary"))
			{
				SetColor(ColorPick.Secondary);
			}
			else if (Input.IsActionPressed("color_tertiary"))
			{
				SetColor(ColorPick.Tertiary);
			}
		}
	}

	private void MouseEntered()
	{
		IsMouseEntered = true;
		
	}

	private void MouseExited()
	{
		IsMouseEntered = false;
	}

	public void SetColor(ColorPick colorPick)
	{
		StandardMaterial3D NewMat = DefaultMaterial;
		switch (colorPick)
		{
			case ColorPick.Primary:
				NewMat = Main.MatLeft;
				break;
			case ColorPick.Secondary:
				NewMat = Main.MatMiddle;
				break;
			case ColorPick.Tertiary:
				NewMat = Main.MatRight;
				break;
		}
		
		if (((StandardMaterial3D)VisualItem.MaterialOverride).AlbedoColor != NewMat.AlbedoColor)
		{
			VisualItem.MaterialOverride = NewMat;
		}
	}

	public void SetColor(Color color)
	{
		if (((StandardMaterial3D)VisualItem.MaterialOverride).AlbedoColor != color)
		{
			var NewMat = new StandardMaterial3D() { AlbedoColor = color };
			VisualItem.MaterialOverride = NewMat;
		}
	}
}
