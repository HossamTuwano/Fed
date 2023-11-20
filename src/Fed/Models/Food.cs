namespace Fed.Models;

class Food
{
    public Guid Id { get; set; }
    public string FoodName { get; set; }
    public double FoodPrice { get; set; }
    public DateTime FedDate { get; set; }
}