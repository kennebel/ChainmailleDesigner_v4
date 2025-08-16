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
    [Export]
    public Node3D RingsHolder { get; set; }

    public override void _Ready()
    {
        // Temp
        Generate(Weave.FourInOne, 23, 45, WeaveState.Compressed);
    }

    public void Generate(Weave weave, int rows, int columns, WeaveState weaveState = WeaveState.Compressed)
    {
        Utilities.RemoveChildren(RingsHolder);

        switch (weave)
        {
            case Weave.FourInOne:
                GenerateFourInOne(rows, columns, weaveState);
                break;
        }
    }

    private void GenerateFourInOne(int rows, int columns, WeaveState weaveState)
    {
        var RowOffset = 0f;
        var AlternateRowOffset = weaveState == WeaveState.Compressed ? 0.5f : 0.7f;
        var RingRotation = -Utilities.HalfPi;

        Node3D NewRing;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (RowOffset != 0f && j == columns - 1) { continue; }

                NewRing = RingTemplate.Instantiate<Node3D>();
                NewRing.Position = new Vector3(j + RowOffset, 0f, i);
                NewRing.Rotation = new Vector3(0f, RingRotation, 0f);
                ((RingControl)NewRing).Main = Main;

                RingsHolder.AddChild(NewRing);
            }

            RowOffset = (RowOffset == AlternateRowOffset) ? 0f : AlternateRowOffset;
            RingRotation = (RingRotation == Utilities.HalfPi) ? -Utilities.HalfPi : Utilities.HalfPi;
        }
    }
}
