namespace Chapter.State
{
    public class BikeStateContext
    {
        public IBikeState CurrentState { get; set; }
        private readonly BikeController _bikeController;
        public BikeStateContext(BikeController bikeController)
        {
            _bikeController = bikeController;
        }

        /*
         * Can set CurrentState manually and then transition by callng this method.
         */
        public void Transition()
        {
            CurrentState.Handle(_bikeController);
        }

        /*
         * This method transitions to state provided.
         */
        public void Transition(IBikeState state)
        {
            CurrentState = state;
            CurrentState.Handle(_bikeController);
        }


    }
}