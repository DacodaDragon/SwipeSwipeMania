namespace SwipeSwipeMania
{
    public struct ArrowInitialData
    {
        public float beatTime;
        public ArrowDirection direction;

        public ArrowInitialData(float beatTime, ArrowDirection direction)
        {
            this.beatTime = beatTime;
            this.direction = direction;
        }
    }
}