namespace MuIn.Domain.Aggregates
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; } = string.Empty;
    }
}

/***
 *Business rules:
 *- Can not delete a color if it has been used in a product and that product has been sold
 *- When delete color, do not remove product
 * 
 * 
 * 
 * ***/