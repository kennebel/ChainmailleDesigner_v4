using Godot;
using System;

public partial class Utilities : Node
{
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
