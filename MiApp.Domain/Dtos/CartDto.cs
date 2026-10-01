namespace MiApp.Domain.Dtos;

public class CartDto
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Date { get; set; } = string.Empty;

    public List<CartProductDto> Products { get; set; } = new();
}