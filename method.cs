double gaussian(double x, double mean, double sigma)
{
    return Math.Exp(-0.5 * Math.Pow((x - mean) / sigma, 2)) / (sigma * 2.5);
}
public void BLOBGaussian(double Price, int Count, double sigma)
{
    if (Count < 5)
    {
        throw new ArgumentException("order count cannot be lower than 5");
    }
    if (Count % 2 != 0)
    {
        Count--;
    }
    var xes = Enumerable.Range(-1*Count/2, Count+1);
    var yes = xes.Select(x => Math.Sign(x) * (1 / gaussian(x, 0, sigma) - sigma * 2.5)).ToList();
    MessageBox.Show(string.Join("\n", yes));
    yes.ForEach(x => BuyLimit(Price + x));
}