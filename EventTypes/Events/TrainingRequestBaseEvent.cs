using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Events
{
    public abstract class TrainingRequestBaseEvent : IEvent
    {
        public string TrainerEmail { get; set; }
        public string TrainerFirstName { get; set; }
        public string TrainerLastName { get; set; }

        public string UserUsername { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
