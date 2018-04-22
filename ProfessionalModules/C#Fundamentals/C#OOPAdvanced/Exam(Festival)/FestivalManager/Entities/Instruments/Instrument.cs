using System;

namespace FestivalManager.Entities.Instruments
{
	using Contracts;

	public abstract class Instrument : IInstrument
	{
		private double wear;
		private const int MaxWear = 100;

		protected Instrument()
		{
			this.Wear = MaxWear;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
                double val = value;
                if (val<0)
                {
                    val = 0;
                }
                if (val>100)
                {
                    val = 100;
                }
                this.wear = val;
			}
		}

		protected abstract int RepairAmount { get; }

        public void Repair()
        {
            this.Wear += this.RepairAmount;
        }

        public void WearDown()
        {
            this.Wear -= this.RepairAmount;
        }

		public bool IsBroken => this.Wear <= 0;
	}
}
