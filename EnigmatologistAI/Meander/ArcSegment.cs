namespace EnigmatologistAI.Meander
{
    public class ArcSegment
    {
        public ArcSegment(int a, int b, char side)
        {
            PositionA = a;
            PositionB = b;
            MaxPosition = a > b ? a : b;
            MinPosition = a < b ? a : b;
            Side = side;
            IsSweepClockwise = (a < b && side == 'R') || (b < a && side == 'L');
        }

        public int PositionA { get; set; }
        public int PositionB { get; set; }
        public int MaxPosition { get; set; }
        public int MinPosition { get; set; }
        public bool IsSweepClockwise { get; set; }
        public char Side { get; set; }
        public string GetSvgPath()
        {
            var rx = 20;
            var ry = 20;
            var angle = 0;
            var largeArcFlag = 0;
            var sweepFlag = IsSweepClockwise ? 1 : 0;
            var x = 0;
            var y = (PositionB - PositionA) * 50;
            return $"a {rx} {ry}, {angle}, {largeArcFlag} {sweepFlag}, {x} {y}";
        }
    }
}
