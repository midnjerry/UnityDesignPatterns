namespace Chapter.Command
{
    public class TurnLeft : Command
    {
        private BikeController _controller;
        public TurnLeft(BikeController bikeController)
        {
            _controller = bikeController;
        }
        public override void Execute()
        {
            _controller.Turn(BikeController.Direction.LEFT);
        }
    }
}