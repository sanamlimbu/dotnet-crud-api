using System;
using dotnet_crud_api.Entities;

namespace dotnet_crud_api.Models;

	public class DbHelper
	{
		private readonly DotNetCrudApiContext _context;
		public DbHelper(DotNetCrudApiContext context)
		{
			_context = context;
		}

    public List<ProductModel> GetProducts()
    {
        List<ProductModel> resp = new List<ProductModel>();
        var dataList = _context.Products.ToList();

        dataList.ForEach(row => resp.Add(
            new ProductModel()
            {
                id = row.id.ToString(),
                name = row.name,
                slug = row.slug,
                description = row.description,
                quantity = row.quantity,
                price = row.price,
                manufactured_date= row.manufactured_date,
            }));

        return resp;
    }

    public ProductModel? GetProductById(string id)
    {
        var guid = new Guid(id);
        ProductModel resp = new ProductModel();
        var data = _context.Products.Where(d=> d.id.Equals(guid)).FirstOrDefault();
        if (data != null)
        {
            resp.id = data.id.ToString();
            resp.name = data.name;
            resp.slug = data.slug;
            resp.description = data.description;
            resp.price = data.price;
            resp.quantity = data.quantity;
            return resp;
        }
        return null;
    }

    public void CreateProduct(ProductModel model)
    {
        Product product = new Product();

        product.name = model.name;
        // TODO slug generator
        product.slug = model.slug;
        product.description = model.description;
        product.quantity = model.quantity;
        product.price = model.price;
        product.manufactured_date = model.manufactured_date;

        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(string id, ProductModel model)
    {
        var guid = new Guid(id);
        var product = _context.Products.Where(p => p.id.Equals(guid)).FirstOrDefault();

        if (product != null)
        {
            product.name = model.name;
            // TODO slug generator
            product.slug = model.slug;
            product.description = model.description;
            product.quantity = model.quantity;
            product.price = model.price;
            product.manufactured_date = model.manufactured_date;

            _context.SaveChanges();
        }
    }

    public void DeleteProduct(string id)
    {
        var product = _context.Products.Where(p => p.id.Equals(id)).FirstOrDefault();
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}

