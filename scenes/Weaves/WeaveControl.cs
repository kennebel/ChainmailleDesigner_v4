using Godot;
using System;

public partial class WeaveControl : Node3D
{
    public enum Weave { FourInOne, SixInOne, DragonScale, Scales }

    [Export]
    public MainControl Main { get; set; }
    [Export]
    public PackedScene RingTemplate { get; set; }

    public void Generate(Weave weave, int rows, int columns)
    {
        Utilities.RemoveChildren(this);

        switch (weave)
        {
            case Weave.FourInOne:
                GenerateFourInOne(rows, columns);
                break;
        }
    }

    private void GenerateFourInOne(int rows, int columns)
    {
        if ((rows % 2) == 0) { rows++; }
        if ((columns % 2) == 0) { columns++; }

        var RowHalf = (int)(rows / 2f);
        var ColHalf = (int)(columns / 2f);

        for (int j = -ColHalf; j <= ColHalf; j++)
        {
            for (int i = -RowHalf; i <= RowHalf; i++)
            {

            }
        }
    }
}
