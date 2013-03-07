using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbile_phone_device
{
    class Battery
    {
        private string model;

        public string Model
        {
            get { return model; }
            set 
            {
                if (value == null)
                    model = "no brand";
                else
	            model = value; }
        }
        private double hoursIdle;

        public double HoursIdle
        {
            get { return hoursIdle; }
            set { hoursIdle = value; }
        }
        private double hoursTalk;

        public double HoursTalk
        {
            get { return hoursTalk; }
            set { hoursTalk = value; }
        }
        private BatteryType type;

        internal BatteryType Type
        {
            get { return type; }
            set { type = value; }
        }

        public enum BatteryType
        {
            LiIon, NiMH, NiCd
        }

        public Battery(string batteryModel)
            : this(batteryModel, BatteryType.LiIon)
        {
        }

        public Battery(string batteryModel, BatteryType batteryType)
        {
            this.Model = batteryModel;
            this.Type = batteryType;
            this.HoursIdle = 0;
            this.HoursTalk = 0;
        }

        public override string ToString()
        {
            string str = "Battery Model: " + this.model;
            str += "\nHours Idle: " + this.hoursIdle;
            str += "\nHours Talk: " + this.hoursTalk;
            str += "\nBattery Type: " + this.type;
            return str;
        }

    }
}
