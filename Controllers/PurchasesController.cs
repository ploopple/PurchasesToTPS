using Microsoft.AspNetCore.Mvc;

namespace PurchasesToTPS.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    public class PurchasesController : ControllerBase
    {
        //Create static array of purchases with fake values
        readonly Purchases[] allCurrentPurchase =
        {
            new Purchases() { ItemNo = 1,Amount = 1,PurchaseDate = new DateTime(2019,11,26,16,09,31)},
            new Purchases() { ItemNo = 2,Amount = 5,PurchaseDate = new DateTime(2019,11,26,16,09,31)},
            new Purchases() { ItemNo = 3,Amount = 56,PurchaseDate = new DateTime(2019,11,26,16,09,32)},
            new Purchases() { ItemNo = 4,Amount = 22,PurchaseDate = new DateTime(2019,11,26,16,09,32)},
            new Purchases() { ItemNo = 5,Amount = 154.5,PurchaseDate = new DateTime(2019,11,26,16,09,32)},
            new Purchases() { ItemNo = 6,Amount = 35.56,PurchaseDate = new DateTime(2019,11,26,16,09,32)},

        };

        //Make an post api
        [HttpPost()]
        public Purchases[] Post([FromForm] TPS TPSBody)
        {
            //Declare a varable to save the result array and declare it as an empty array  
            Purchases[] firstBulSizeOfPurchaese = Array.Empty<Purchases>();

            //make a loop to get the first numbers of the allCurrentPurchase array and pass it to firstBulSizeOfPurchaese
            for (int i = 0; i < TPSBody.BulkSize; i++)
            {
                //if the allCurrentPurchase length is less than i then break the loop
                if (!(allCurrentPurchase.Length > i))
                {
                    break;
                }
                //if the date of allCurrentPurchase in the position of i in the date value is bigger than or equals TPSBody date add the allCurrentPurchase in the position of i  to firstBulSizeOfPurchaese
                if (allCurrentPurchase[i].PurchaseDate >= TPSBody.StartFrom)
                {
                    Array.Resize(ref firstBulSizeOfPurchaese, firstBulSizeOfPurchaese.Length + 1);
                    firstBulSizeOfPurchaese[firstBulSizeOfPurchaese.Length - 1] = allCurrentPurchase[i];
                }
                //if nothing is true the continue the loop
                continue;
            }
            
            return firstBulSizeOfPurchaese;
        }
    }
}