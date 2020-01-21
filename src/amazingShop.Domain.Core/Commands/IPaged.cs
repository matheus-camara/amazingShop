namespace amazingShop.Domain.Core.Commands
{
    public interface IPaged
    {
        int Skip { get; set; }

        int Take { get; set; }
    }
}