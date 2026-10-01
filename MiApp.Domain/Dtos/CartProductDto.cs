namespace MiApp.Domain.Dtos;

public class CartProductDto
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public string ProductName { get; set; } = string.Empty;
}