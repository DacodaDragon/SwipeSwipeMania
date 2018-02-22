namespace SwipeSwipeMania
{
    public struct Song
    {
        public readonly string title;
        public readonly string artist;
        public readonly float bpm;
        public readonly float offset;
        public readonly StepData[] datas;
        public readonly bool selectable;

        public Song(string title, string artist, float bpm, float offset, StepData[] data, bool selectable)
        {
            this.title = title;
            this.bpm = bpm;
            this.offset = offset;
            this.datas = data;
            this.artist = artist;
            this.selectable = selectable;
        }
    }
}