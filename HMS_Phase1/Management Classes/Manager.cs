
namespace HMS_Phase1.Management_Classes
{
    public abstract class Manager
    {
        protected HMSContext context = new HMSContext();

        public abstract void TrackOptions(string option);

    }
}
