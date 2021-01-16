using System;
using System.Collections.Generic;
using System.Text;

namespace DesignProblems
{
    public class ParkingLotSystem
    {
        
        public ParkingLotSystem()
        {

        }

        public ParkingSpot Park(Vehicle vehicle)
        {
            //todo
            return null;
        }
        
        public void UnPark(ParkingSpot parkingSpot)
        {
            //todo
            return;
        }

    }

    public enum ParkingSpotType { small, medium, large };
    public abstract class Vehicle
    {        
        protected string LicensePlate;
        protected ParkingSpotType ParkingTypeRequired;
        protected Vehicle(string licensePlate=null)
        {
            LicensePlate = licensePlate;
        }

    }

    public class MotorCycle : Vehicle
    {
        public MotorCycle(string licensePlate):base(licensePlate)
        {   
            ParkingTypeRequired = ParkingSpotType.small;
        }
    }

    public class Compact : Vehicle
    {
        public Compact(string licensePlate) : base(licensePlate)
        {
            ParkingTypeRequired = ParkingSpotType.small;
        }
    }

    public class Car : Vehicle
    {
        public Car(string licensePlate) : base(licensePlate)
        {
            ParkingTypeRequired = ParkingSpotType.medium;
        }
    }

    public class Bus : Vehicle
    {
        public Bus(string licensePlate) : base(licensePlate)
        {
            ParkingTypeRequired = ParkingSpotType.large;
        }
    }


    public abstract class ParkingSpot
    {
        int ParkingSpotId;
        protected decimal latitute;
        protected decimal longitude;
        protected ParkingSpotType parkingSpotType;
        protected bool IsFree = true;
        public Vehicle vehicleParked;
        protected decimal HourlyRate;
    }
    public class SmallParkingSpot:ParkingSpot
    {

    }
}
