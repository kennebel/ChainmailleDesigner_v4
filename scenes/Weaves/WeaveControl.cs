using Godot;
using System;

public partial class WeaveControl : Node3D
{
    public enum Weave { FourInOne, SixInOne, DragonScale, Scales }
    public enum WeaveState { Compressed, Open }

    [Export]
    public MainControl Main { get; set; }
    [Export]
    public PackedScene RingTemplate { get; set; }

    public void Generate(Weave weave, int rows, int columns, WeaveState weaveState = WeaveState.Compressed)
    {
        Utilities.RemoveChildren(this);

        switch (weave)
        {
            case Weave.FourInOne:
                GenerateFourInOne(rows, columns, weaveState);
                break;
        }
    }

    private void GenerateFourInOne(int rows, int columns, WeaveState weaveState)
    {
        
        for (int i = -rows; i <= rows; i++)
        {
            for (int j = -columns; j <= columns; j++)
            {

            }
        }
    }
}
