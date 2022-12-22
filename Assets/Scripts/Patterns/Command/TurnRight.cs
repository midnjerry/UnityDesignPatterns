namespace Chapter.Command
{
    public class TurnRight : Command
    {
        private BikeController _controller;

        public TurnRight(BikeController bikeController)
        {
            _controller = bikeController;
        }
        public override void Execute()
        {
            _controller.Turn(BikeController.Direction.RIGHT);
        }
    }
}
