using MongoDB.Entities;

namespace USP_Domain.Entities;

public class User:Entity
{
    public string  FirstName { get; set; }
    public string  LastName { get; set; }
    public string Email{ get; set; }
    
    [InverseSide]
    public Many<Product,User> ReferencedManyToManyProducts { get; set; }

    public User()
    {
        this.InitManyToMany(()=>ReferencedManyToManyProducts,product =>product.ReferencedManyToManyUser);
    }
}