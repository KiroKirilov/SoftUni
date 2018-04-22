namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private TimeSpan defaultMaxSpan = new TimeSpan(0, 15, 0);

		public Short(string name) 
			: base(name)
		{
		}

        public override TimeSpan MaxDuration => this.defaultMaxSpan;
    }
}