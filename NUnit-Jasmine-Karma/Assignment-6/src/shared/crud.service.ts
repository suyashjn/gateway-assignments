import { Injectable } from '@angular/core';
import { Product } from 'src/models/product';

@Injectable({
  providedIn: 'root',
})
export class CRUDService {
  public products: Product[] = [
    { id: 1, productName: 'Sofa', category: 'Furniture', price: 38000 },
    {
      id: 2,
      productName: 'Dining Room Table',
      category: 'Furniture',
      price: 24600,
    },
    { id: 3, productName: 'Phone', category: 'Electronics', price: 55700 },
    { id: 4, productName: 'PowerBank', category: 'Electronics', price: 4000 },
    { id: 5, productName: 'Shoes', category: 'Footwear', price: 3300 },
  ];
  async getProducts(): Promise<Product[]> {
    return this.products;
  }

  async getProduct(id: number) {
    return this.products.find((x) => x.id == id);
  }

  async createProduct(model: Product) {
    this.products.push(model);
    return this.products;
  }

  async updateProduct(model: Product) {
    this.products.find((x) => x.id == model.id).id = model.id;
    this.products.find((x) => x.id == model.id).productName = model.productName;
    this.products.find((x) => x.id == model.id).category = model.category;
    this.products.find((x) => x.id == model.id).price = model.price;
    return this.products;
  }

  async deleteProduct(id: number) {
    this.products.splice(id, 1);
    return this.products;
  }
}
