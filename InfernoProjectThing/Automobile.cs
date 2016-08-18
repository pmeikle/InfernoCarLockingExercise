using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InfernoProjectThing
{
    public class Automobile
    {
        private CarObserver carObserver;
        public IList<Door> doors { get; set; }
        private SpeedChangedPublisher speedEventPublisher { get; set; }

        public Automobile()
        {
            speedEventPublisher = new SpeedChangedPublisher();
            carObserver = new CarObserver(this, speedEventPublisher);
            doors = new List<Door>();
            doors.Add(new Door());
            doors.Add(new Door());
            doors.Add(new Door());
            doors.Add(new Door());
            speed = 0;
        }

        private double speed { get; set; }

        public bool AreDoorsLocked()
        {
            return doors.All(d => d.IsLocked);
        }

        public void SetSpeed(double newSpeed)
        {
            speed = newSpeed;
            speedEventPublisher.SetSpeed(newSpeed);
        }
    }

    public class SpeedChangedPublisher
    {

        public event EventHandler<SpeedChangedEvent> speedChangedEvent;

        internal virtual void OnRaiseCustomEvent(SpeedChangedEvent e)
        {
            EventHandler<SpeedChangedEvent> handler = speedChangedEvent;
            handler?.Invoke(this, e);
        }

        public void SetSpeed(double newSpeed)
        {
            OnRaiseCustomEvent(new SpeedChangedEvent(newSpeed));
        }
    }
}

