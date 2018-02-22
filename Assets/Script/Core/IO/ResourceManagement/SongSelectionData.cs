using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectionData : DDOLSingleton<SongSelectionData>
{
    private int SongIndex = 0;
    private int DiffIndex = 0;

    public int SelectedSongIndex { get { return SongIndex; } set { SongIndex = value; } }
    public int SelectedDiffIndex { get { return DiffIndex; } set { DiffIndex = value; } }
}
