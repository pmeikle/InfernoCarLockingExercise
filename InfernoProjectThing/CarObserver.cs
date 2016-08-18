using System.Linq;

namespace InfernoProjectThing
{
    public class CarObserver
    {
        public Automobile car { get; set; }

        public CarObserver(Automobile car, SpeedChangedPublisher publisher)
        {
            this.car = car;
            publisher.speedChangedEvent += HandleSpeedChangedEvent;
        }

        public void HandleSpeedChangedEvent(object o, SpeedChangedEvent e)
        {
            if(e.speed >= 15)
                car.doors.ToList().ForEach(c => c.Lock());
        }
    }
}