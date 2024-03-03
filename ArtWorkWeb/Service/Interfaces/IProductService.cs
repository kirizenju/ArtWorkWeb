using DataTier.View.Common;
using DataTier.View.Product;

namespace ArtWorkWeb.Service.Interfaces
{
    public interface IProductService
    {
        KeyValuePair<MessageViewModel, List<UserProductViewModel>> GetAllProductUser(int id);
        KeyValuePair<MessageViewModel,  GetHotProduct();
        KeyValuePair<MessageViewModel, List<ImageViewModel>> GetImage(int id);
    }
}
