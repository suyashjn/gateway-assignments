import { TestBed } from '@angular/core/testing';
import { HttpCRUDService } from 'src/shared/http-crud.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { PostsComponent } from './posts.component';

describe('Post Component', () => {
  let component: PostsComponent;
  let service: HttpCRUDService;
  beforeEach(() => {
    TestBed.configureTestingModule({ imports: [HttpClientTestingModule] });
    service = TestBed.inject(HttpCRUDService);
    component = new PostsComponent(service);
  });
  afterEach(() => {
    service = null;
    component = null;
  });

  it('should call GetAllPosts()', (done) => {
    // Act
    component.GetAllPosts().then((data) => {
      // Assert
      expect(data).toBeTruthy();
      console.log('hello', data);
      done();
    });
  });

  it('should call GetSinglePost()', (done) => {
    // Act
    component.GetSinglePost(3).then((data) => {
      // Assert
      expect(data).toBeTruthy();
      done();
    });
  });

  it('should call addPost()', (done) => {
    // Act
    component
      .addPost({
        id: 3,
        userId: 1,
        title: 'Where, What, Why',
        body: 'On the other hand, we denounce with righteous indignation and dislike men who are so beguiled',
      })
      .then((data) => {
        // Assert
        expect(data).toBeTruthy();
        done();
      });
  });

  it('should call updatePost()', (done) => {
    // Act
    component
      .updatePost({
        id: 3,
        userId: 1,
        title: 'Where, What, Why',
        body: 'But in certain circumstances and owing to the claims of duty or the obligations of business it will frequently occur',
      })
      .then((data) => {
        // Assert
        expect(data).toBeTruthy();
        done();
      });
  });

  it('should call deletePost()', (done) => {
    // Act
    component.deletePost(5).then((data) => {
      // Assert
      expect(data).toBeTruthy();
      done();
    });
  });
});
