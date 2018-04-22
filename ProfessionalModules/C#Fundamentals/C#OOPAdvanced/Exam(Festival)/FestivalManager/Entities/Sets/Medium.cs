namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private TimeSpan defaultMaxSpan = new TimeSpan(0, 40, 0);

        public Medium(string name)
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => this.defaultMaxSpan;
    }
}