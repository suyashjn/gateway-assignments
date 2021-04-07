import { TestBed } from '@angular/core/testing';
import { CRUDService } from 'src/shared/crud.service';
import { AppComponent } from './app.component';

describe('UserComponent', () => {
  let component: AppComponent;
  let service: CRUDService;

  beforeEach(() => {
    service = new CRUDService();
    component = new AppComponent(service);
  });
  afterEach(() => {
    service = null;
    component = null;
  });

  it('should call GetAllProducts()', (done) => {
    //Arrange
    let record: number = 5;

    // Act
    component.GetAllProducts().then((data) => {
      // Assert
      expect(data.length).toEqual(record);
      done();
    });
  });

  it('should call GetSingleProduct(2)', (done) => {
    // Act
    component.GetSingleProduct(2).then((data) => {
      // Assert
      expect(data).toBeTruthy();
      done();
    });
  });

  it('should call AddProduct() with data', (done) => {
    //Arrange
    let record: number = 6;

    // Act
    component
      .AddProduct({
        id: 6,
        category: 'Baking Flours & Meals',
        price: 320,
        productName: 'Wheat Flour',
      })
      .then((data) => {
        // Assert
        expect(data.length).toEqual(record);
        done();
      });
  });

  it('should call updateProduct() with data', (done) => {
    //Arrange
    let record: number = 5;

    // Act
    component
      .UpdateProduct({
        id: 6,
        category: 'Baking Flours & Meals',
        price: 700,
        productName: 'Wheat Flour',
      })
      .then((data) => {
        // Assert
        expect(data.length).toEqual(record);
        done();
      });
  });

  it('should call updateProduct() with data', (done) => {
    //Arrange
    let record: number = 4;

    // Act
    component.RemoveProduct(2).then((data) => {
      // Assert
      expect(data.length).toEqual(record);
      done();
    });
  });
});
