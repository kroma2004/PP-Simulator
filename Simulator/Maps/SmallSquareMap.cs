namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public int Size { get; }
        private readonly Rectangle _bounds;

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Rozmiar mapy musi byc miedzy 5 a 20 punktow.");
            }
            Size = size;
            _bounds = new Rectangle(0, 0, Size - 1, Size - 1);
        }

        public override bool Exist(Point point)
        {
            return _bounds.Contains(point);
        }

        public override Point Next(Point point, Direction direction)
        {
            var next = direction switch
            {
                Direction.Up => point.Next(Direction.Up),
                Direction.Down => point.Next(Direction.Down),
                Direction.Left => point.Next(Direction.Left),
                Direction.Right => point.Next(Direction.Right),
                _ => point
            };

            return Exist(next) ? next : point;
        }

        public override Point NextDiagonal(Point point, Direction direction)
        {
            var nextDiagonal = direction switch
            {
                Direction.Up => point.NextDiagonal(Direction.Up),
                Direction.Right => point.NextDiagonal(Direction.Right),
                Direction.Down => point.NextDiagonal(Direction.Down),
                Direction.Left => point.NextDiagonal(Direction.Left),
                _ => point
            };

            return Exist(nextDiagonal) ? nextDiagonal : point;
        }
    }
}
