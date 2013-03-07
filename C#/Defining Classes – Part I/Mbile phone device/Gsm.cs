using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mbile_phone_device
{
    class Gsm
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private string owner;

        public string Owner
        {
            get { return owner; }
            set 
            {
                if (value == null)
                    owner = "none";
                else
		    owner = value; 
            }

        }

        private Battery battery;
        private Display display;

        private static Gsm iPhone4S = new Gsm("iPhone 4S", "Apple", 100);
        public static Gsm IPhone4S { get { return iPhone4S; } }


        private List<Call> callHistory;

        internal List<Call> CallHistory
        {
            get { return callHistory; }
            set { callHistory = value; }
        }


        public void AddCall(Call call)
        {
            callHistory.Add(call);
        }

        public void DelCall(Call call)
        {
            callHistory.Remove(call);
        }

        public void clearCallHistory()
        {
            callHistory.Clear();
        }

        public double CalcCallsPrice(double price)
        {
            double cost = 0;
            foreach (var call in callHistory)
            {
                cost += call.Duration * price / 60;
            }
            return cost;
        }

        #region Constructors
        public Gsm(string model, string manufacturer)
            : this(model, manufacturer, 0)
        {
        }
        public Gsm(string model, string manufacturer, double price)
            : this(model, manufacturer, price, null)
        {
        }
        public Gsm(string model, string manufacturer, double price, string owner)
            : this(model, manufacturer, price, owner, null)
        {
        }
        public Gsm(string model, string manufacturer, double price, string owner, string batteryModel)
            : this(model, manufacturer, price, owner, batteryModel, Battery.BatteryType.LiIon)
        {
        }
        public Gsm(string model, string manufacturer, double price, string owner, string batteryModel, Battery.BatteryType batteryType)
            : this(model, manufacturer, price, owner, batteryModel, batteryType, null)
        {
        }
        public Gsm(string model, string manufacturer, double price, string owner, string batteryModel, Battery.BatteryType batteryType, string displaySize)
            : this(model, manufacturer, price, owner, batteryModel, batteryType, displaySize, 0)
        {
        }
        public Gsm(string model, string manufacturer, double price, string owner, string batteryModel, Battery.BatteryType batteryType, string displaySize,
                int displayNumColors)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;

            battery = new Battery(batteryModel, batteryType);
            display = new Display(displaySize, displayNumColors);
        }
        #endregion

        public override string ToString()
        {
            string gsm = "-----------------------\nMobile Phone Deice Info \n-----------------------";
            gsm += "\nModel: " + this.model;
            gsm += "\nManufacturer: " + this.manufacturer;
            gsm += "\nPrice: $" + this.price;
            gsm += "\nOwner: " + this.owner;
            gsm += "\n" + battery;
            gsm += "\n" + display;
            
            return gsm;
        }
    }
}
