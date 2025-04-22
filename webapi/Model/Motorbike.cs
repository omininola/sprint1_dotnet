namespace webapi.Model
{
    public class Motorbike
    {
        public int Id { get; set; }
        public IotDevice IotDevice { get; set; }
        public Status Status { get; set; }
        public MotorbikeModel Model { get; set; }
        public string Plate { get; set; }
        public MotorbikeLot Lot { get; set; }

    }
}
