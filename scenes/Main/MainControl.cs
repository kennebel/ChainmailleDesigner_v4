using Godot;
using System;

public partial class MainControl : Node
{
    public enum ColorSelector { Left, Middle, Right }

    [Export]
    public RingControl RingTemplate { get; set; }
    [Export]
    public Color ColorLeft { get; set; } = new Color(0.9f, 0.9f, 0.9f);
    [Export]
    public Color ColorMiddle { get; set; } = new Color(0.1f, 0.9f, 0.1f);
    [Export]
    public Color ColorRight { get; set; } = new Color(0.1f, 0.1f, 0.1f);

    public StandardMaterial3D MatLeft { get; set; } = new StandardMaterial3D();
    public StandardMaterial3D MatMiddle { get; set; } = new StandardMaterial3D();
    public StandardMaterial3D MatRight { get; set; } = new StandardMaterial3D();

    public override void _Ready()
    {
        UpdateMatFromColor(ColorSelector.Left);
        UpdateMatFromColor(ColorSelector.Middle);
        UpdateMatFromColor(ColorSelector.Right);
    }

    private void UpdateMatFromColor(ColorSelector colorSelector)
    {
        switch (colorSelector)
        {
            case ColorSelector.Left:
                MatLeft.AlbedoColor = ColorLeft;
                break;
            case ColorSelector.Middle:
                MatMiddle.AlbedoColor = ColorMiddle;
                break;
            case ColorSelector.Right:
                MatRight.AlbedoColor = ColorRight;
                break;
        }
    }
}
