namespace BigBangExpansionSimulation
{
    public interface IExpansionKernel
    {
        double EnergyPdf(double r);

        double Clip(double r);
    }
}