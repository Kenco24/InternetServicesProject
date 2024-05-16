using InternetServicesProj.Services.DTOs;

namespace InternetServicesProj.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO AddProduct(ProductDTO productDTO);
        void UpdateProduct(ProductDTO productDTO);
        void DeleteProduct(int id);
        void RestockProduct(int productId, int quantityToAdd);
    }
}
