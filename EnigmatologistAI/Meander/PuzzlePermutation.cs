using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EnigmatologistAI.Meander
{
    public class PuzzlePermutation
    {
        public PuzzlePermutation(IEnumerable<int> sequnce)
        {
            MeanderOrder = sequnce.ToList();
            ArcSegments = new List<ArcSegment>();

            var arcSide = 'R';
            for (var i = 1; i < MeanderOrder.Count(); ++i)
            {
                ArcSegments.Add(new ArcSegment(MeanderOrder[i - 1], MeanderOrder[i], arcSide));
                arcSide = arcSide == 'R' ? 'L' : 'R';
            }

            IsValid = !ArcSegments.Any(a1 => ArcSegments.Any(a2 =>
                a1.Side == a2.Side // arcs are on the same side
                && ((a1.MinPosition > a2.MinPosition && a1.MinPosition < a2.MaxPosition // and min position is inside another arc
                && (a1.MaxPosition < a2.MinPosition || a1.MaxPosition > a2.MaxPosition)) // and max position is outside the other arc
                || (a1.MaxPosition > a2.MinPosition && a1.MaxPosition < a2.MaxPosition // or max position is inside another arc
                && (a1.MinPosition < a2.MinPosition || a1.MinPosition > a2.MaxPosition))) // and min position is outside the other arc
            ));
        }

        public IList<int> MeanderOrder { get; set; }
        public IList<ArcSegment> ArcSegments { get; set; }
        public bool IsValid { get; set; }
        public int PositionSpacing { get; set; }
        public string MeanderOrderString => string.Join("-", MeanderOrder);

        public string GetSvg()
        {
            var startingX = ArcSegments.First().PositionA * 50;
            var lineLength = (ArcSegments.Count() * 50) + 100;
            var pointsSvg = "";
            for(var i = 1; i <= MeanderOrder.Count(); ++i)
            {
                pointsSvg += $@"<circle cx=""100"" cy=""{i * 50}"" r=""10"" fill=""Blue"" />
                    <text x=""100"" y=""{i * 50}"" text-anchor=""middle"" fill=""white"" font-size=""15px"" font-family=""Arial"" dy="".3em"">{i}</text>";
            }

            var svg = $@"<svg xmlns=""http://www.w3.org/2000/svg"" width=""200"" height=""{lineLength}"" version=""1.1"" class=""card-img-bottom"">
                            <path d=""M 100 {startingX} {string.Join(" ", ArcSegments.Select(s => s.GetSvgPath()))}"" stroke=""orange"" stroke-width=""2"" fill=""none""/>
                            <path d=""M 100 0 l 0 {lineLength}"" stroke=""Blue"" stroke-width=""2"" fill=""none""/>
                            {pointsSvg}
                         </svg>";
            return svg;
        }
    }
}
