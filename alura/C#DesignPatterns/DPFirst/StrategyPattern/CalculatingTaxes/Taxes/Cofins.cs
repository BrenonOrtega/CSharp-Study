namespace DPFirst.StrategyPattern.CalculatingTaxes.Taxes{
    class Cofins : BaseTax
    {
        public override double Calculate(Budget budget)
        {
            return budget * 0.15;
        }
    }
}