namespace Fed;

public interface IFoodService
{
    Task<IResult> CreatedFood(FoodRequest food);
}