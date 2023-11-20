using Microsoft.EntityFrameworkCore;

namespace Fed;

public class FoodService : IFoodService
{
    private readonly FedDbContext _context;

    public FoodService(FedDbContext context)
    {
        _context = context;
    }

    public async Task<IResult> GetFeds()
    {
        var feds = await _context.Foods.ToListAsync();
        return Results.Ok(feds);
    }
    public async Task<IResult> CreatedFood(FoodRequest food)
    {
        var createdFood = _context.Foods.Add(new Food
        {
            FoodName = food.foodName,
            FoodPrice = food.foodPrice ?? 2000,
            FedDate = food.fedDate ?? DateTime.Now,

        }
        );

        await _context.SaveChangesAsync();

        return Results
                .Created($"/foods/{createdFood.Entity}", createdFood.Entity);

    }

    public async Task<IResult> DeleteFood(int id)
    {
        var food = await _context.Foods.FindAsync(id);

        if (food == null)
        {
            return Results.NotFound();
        }

        _context.Foods.Remove(food);

        await _context.SaveChangesAsync();

        return Results.NoContent();
    }

}