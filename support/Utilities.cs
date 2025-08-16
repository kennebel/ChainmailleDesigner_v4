using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class Utilities : Node
{
    public const float TwoPi = (float)Math.PI * 2f;
    public const float HalfPi = (float)Math.PI / 2f;

    public static void RemoveChildren(Node3D RemoveFrom)
    {
        var Children = RemoveFrom.GetChildren();
        foreach (var child in Children)
        {
            RemoveFrom.RemoveChild(child);
            child.QueueFree();
        }
    }
}
